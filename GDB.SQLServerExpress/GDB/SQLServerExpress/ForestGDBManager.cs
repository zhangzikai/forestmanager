namespace GDB.SQLServerExpress
{
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class ForestGDBManager
    {
        private List<string> _allDbs = new List<string>();
        private IDataServerManagerAdmin _dsAdmin;
        private ForestGDBInfo _wkGdbInfo;

        public ForestGDBManager(ForestGDBInfo wkGdbInfo)
        {
            this._wkGdbInfo = wkGdbInfo;
            this.initDSAdmin();
        }

        public bool AttachGDB(ForestGDBInfo dbInfo)
        {
            if (this._dsAdmin != null)
            {
                try
                {
                    this._dsAdmin.AttachGeodatabase(dbInfo.DBName, dbInfo.GdbFileName, dbInfo.GdbLogFileName);
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
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

        public TaskResult CreateNewForestGDB(string fileGdbPath)
        {
            if (!this.IsGDBExists(this._wkGdbInfo.DBName))
            {
                this.CreateNewGDB(string.Empty);
            }
            IWorkspace sourceWorkspace = null;
            if (string.IsNullOrEmpty(fileGdbPath))
            {
                string str = this.getTemplateGDBName();
                if (string.IsNullOrEmpty(str))
                {
                    return new TaskResult { 
                        Msg = "模板数据库不存在，请附加,或者指定文件型模板数据库路径!",
                        Success = false
                    };
                }
                sourceWorkspace = this.OpenWorkSpace(str, string.Empty);
            }
            else
            {
                sourceWorkspace = ForestGDBWorkSpaceUtil.GetWorkspace(fileGdbPath);
            }
            if (sourceWorkspace == null)
            {
                return new TaskResult { 
                    Msg = "模板数据库地理空间打开失败！",
                    Success = false
                };
            }
            IWorkspace targetWorkspace = this.OpenWorkSpace(this._wkGdbInfo.DBName, string.Empty);
            if (targetWorkspace == null)
            {
                return new TaskResult { 
                    Msg = "目标数据库地理空间打开失败！",
                    Success = false
                };
            }
            IEnumDataset o = sourceWorkspace.get_Datasets(esriDatasetType.esriDTAny);
            if (o == null)
            {
                return new TaskResult { 
                    Msg = "要素集打开失败!",
                    Success = false
                };
            }
            o.Reset();
            for (IDataset dataset2 = o.Next(); dataset2 != null; dataset2 = o.Next())
            {
                string objectName = dataset2.Name.ToUpper();
                objectName = objectName.Substring(objectName.LastIndexOf('.') + 1);
                esriDatasetType esriDataType = dataset2.Type;
                switch (esriDataType)
                {
                    case esriDatasetType.esriDTFeatureClass:
                    case esriDatasetType.esriDTTable:
                    case esriDatasetType.esriDTFeatureDataset:
                        ForestGDBWorkSpaceUtil.GDBToNewGDB2(sourceWorkspace, targetWorkspace, objectName, esriDataType, false);
                        break;
                }
                Marshal.ReleaseComObject(dataset2);
                dataset2 = null;
            }
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
                o = null;
            }
            if (sourceWorkspace != null)
            {
                Marshal.ReleaseComObject(sourceWorkspace);
                sourceWorkspace = null;
            }
            if (targetWorkspace != null)
            {
                Marshal.ReleaseComObject(targetWorkspace);
                targetWorkspace = null;
            }
            return new TaskResult { 
                Msg = "森林年度更新本底数据库生成完成！",
                Success = true
            };
        }

        public bool CreateNewGDB(string keyText)
        {
            if (this._dsAdmin == null)
            {
                return false;
            }
            try
            {
                if (this._dsAdmin.IsConnectedUserAdministrator)
                {
                    this._dsAdmin.CreateGeodatabase(this._wkGdbInfo.DBName, this._wkGdbInfo.GdbFileName, (this._wkGdbInfo.GDBSize < 0) ? 0 : this._wkGdbInfo.GDBSize, this._wkGdbInfo.GdbLogFileName, (this._wkGdbInfo.LogSize < 0) ? 0 : this._wkGdbInfo.LogSize);
                    return this.UpdateGDBToForest(keyText);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ForestMdfInfo DettachGDB(string dbName)
        {
            if (this._dsAdmin != null)
            {
                this.initDSAdmin();
                if (this._allDbs.Contains(dbName))
                {
                    try
                    {
                        string dataName = string.Empty;
                        string dataPhysicalName = string.Empty;
                        int dataFileSize = -1;
                        string logName = string.Empty;
                        string logPhysicalName = string.Empty;
                        int logFileSize = -1;
                        this._dsAdmin.GetFileProperties(dbName, out dataName, out dataPhysicalName, out dataFileSize, out logName, out logPhysicalName, out logFileSize);
                        this._dsAdmin.DetachGeodatabase(dbName);
                        return new ForestMdfInfo { 
                            DataName = dataName,
                            DataFileName = dataPhysicalName,
                            DataSize = dataFileSize,
                            LogName = logName,
                            LogFileName = logPhysicalName,
                            LogSize = logFileSize,
                            IStatus = true,
                            Satus = "数据库已被从服务器中分离"
                        };
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return null;
        }

        ~ForestGDBManager()
        {
            if (this._dsAdmin != null)
            {
                Marshal.ReleaseComObject(this._dsAdmin);
                this._dsAdmin = null;
            }
        }

        public List<ForestDbName> GetAllGDBS()
        {
            if (this._dsAdmin == null)
            {
                return new List<ForestDbName>();
            }
            try
            {
                IEnumBSTR geodatabaseNames = this._dsAdmin.GetGeodatabaseNames();
                List<ForestDbName> list = new List<ForestDbName>();
                if (geodatabaseNames != null)
                {
                    for (string str = geodatabaseNames.Next(); !string.IsNullOrEmpty(str); str = geodatabaseNames.Next())
                    {
                        string[] strArray = str.Split(new char[] { '_' });
                        int connectedUsers = this._dsAdmin.GetConnectedUsers(str);
                        if (strArray.Length < 3)
                        {
                            ForestDbName item = new ForestDbName {
                                DBName = str
                            };
                            list.Add(item);
                        }
                        else if ("MODULE".Contains(strArray[2]))
                        {
                            ForestDbName name2 = new ForestDbName {
                                DBName = str,
                                GBCode = strArray[1],
                                ConnectedUsers = connectedUsers,
                                AliasName = "年度森林资源更新模板数据库"
                            };
                            list.Add(name2);
                        }
                        else
                        {
                            int num2;
                            int.TryParse(strArray[2], out num2);
                            ForestDbName name3 = new ForestDbName {
                                DBName = str,
                                GBCode = strArray[1],
                                DataYear = num2,
                                ConnectedUsers = connectedUsers,
                                AliasName = string.Concat(new object[] { 
                                    num2,
                                    "年度森林资源更新数据【",
                                    strArray[1],
                                    "】"
                                })
                            };
                            list.Add(name3);
                        }
                    }
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
                return new List<ForestDbName>();
            }
        }

        private string getTemplateGDBName()
        {
            foreach (string str in this._allDbs)
            {
                if (!string.IsNullOrEmpty(str) && str.ToUpper().Contains("MODULE"))
                {
                    return str;
                }
            }
            return string.Empty;
        }

        private void initDSAdmin()
        {
            if (this._wkGdbInfo != null)
            {
                try
                {
                    IDataServerManager manager = new DataServerManagerClass {
                        ServerName = this._wkGdbInfo.GDBServer
                    };
                    manager.Connect();
                    this._dsAdmin = (IDataServerManagerAdmin) manager;
                    this.queryAllDBNames();
                }
                catch (Exception)
                {
                    this._dsAdmin = null;
                }
            }
        }

        public bool IsGDBExists(string gdbName)
        {
            if (this._dsAdmin == null)
            {
                return false;
            }
            this.queryAllDBNames();
            return this._allDbs.Contains(gdbName);
        }

        public bool IsServerOnLine()
        {
            return ((this._dsAdmin != null) && this._dsAdmin.IsConnectedUserAdministrator);
        }

        public IWorkspace OpenWorkSpace(string dbName, string version)
        {
            if (!string.IsNullOrEmpty(dbName))
            {
                if (this._dsAdmin == null)
                {
                    return null;
                }
                try
                {
                    IName name2 = (IName) this._dsAdmin.CreateWorkspaceName(dbName, "VERSION", string.IsNullOrEmpty(version) ? "dbo.Default" : version);
                    return (IWorkspace) name2.Open();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        private int queryAllDBNames()
        {
            if (this._dsAdmin == null)
            {
                return -1;
            }
            try
            {
                IEnumBSTR geodatabaseNames = this._dsAdmin.GetGeodatabaseNames();
                string str = geodatabaseNames.Next();
                if (this._allDbs == null)
                {
                    this._allDbs = new List<string>();
                }
                while (!string.IsNullOrEmpty(str))
                {
                    this._allDbs.Add(str);
                    str = geodatabaseNames.Next();
                }
                if (geodatabaseNames != null)
                {
                    Marshal.ReleaseComObject(geodatabaseNames);
                    geodatabaseNames = null;
                }
                return this._allDbs.Count;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void Release()
        {
            if (this._dsAdmin != null)
            {
                Marshal.ReleaseComObject(this._dsAdmin);
                this._dsAdmin = null;
            }
        }

        public bool UpdateGDBAuthKey(string key)
        {
            if (this._dsAdmin == null)
            {
                return false;
            }
            this.queryAllDBNames();
            if ((this._allDbs != null) && (this._allDbs.Count >= 1))
            {
                foreach (string str in this._allDbs)
                {
                    this.UpdateGDBToForest(key, str);
                }
            }
            return true;
        }

        public bool UpdateGDBToForest(string keyText)
        {
            string str = this._wkGdbInfo.GDBServer.Split(new char[] { '\\' })[0];
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            using (SqlConnection connection = CreateConnection(str, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass, this._wkGdbInfo.DBName))
            {
                connection.Open();
                string str2 = string.Format("UPDATE [{0}].[dbo].[SDE_dbtune] SET config_string='GEOMETRY' WHERE KEYWORD='DEFAULTS' AND PARAMETER_NAME='GEOMETRY_STORAGE'", this._wkGdbInfo.DBName);
                SqlCommand command = connection.CreateCommand();
                command.CommandText = str2;
                command.ExecuteNonQuery();
                command.Dispose();
                command = null;
                if (string.IsNullOrEmpty(keyText))
                {
                    keyText = "sdeworkgroup,100,sdeworkgroup,01-jan-2030,IE7XTNBJ3Y4JYJT15089";
                }
                string str3 = string.Format("UPDATE [{0}].[dbo].[SDE_server_config] set char_prop_value='{1}' WHERE prop_name='AUTH_KEY'", this._wkGdbInfo.DBName, keyText);
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

        private bool UpdateGDBToForest(string keyText, string dbName)
        {
            string str = this._wkGdbInfo.GDBServer.Split(new char[] { '\\' })[0];
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            using (SqlConnection connection = CreateConnection(str, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass, dbName))
            {
                connection.Open();
                string str2 = string.Format("UPDATE [{0}].[dbo].[SDE_dbtune] SET config_string='GEOMETRY' WHERE KEYWORD='DEFAULTS' AND PARAMETER_NAME='GEOMETRY_STORAGE'", dbName);
                SqlCommand command = connection.CreateCommand();
                command.CommandText = str2;
                command.ExecuteNonQuery();
                command.Dispose();
                command = null;
                if (string.IsNullOrEmpty(keyText))
                {
                    keyText = "sdeworkgroup,100,sdeworkgroup,01-jan-2030,IE7XTNBJ3Y4JYJT15089";
                }
                string str3 = string.Format("UPDATE [{0}].[dbo].[SDE_server_config] set char_prop_value='{1}' WHERE prop_name='AUTH_KEY'", dbName, keyText);
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

