namespace GDB.SQLServerExpress.vTasks.vTasks
{
    using ESRI.ArcGIS.esriSystem;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class NewForestGDBTemplateTask : ForestGDBTask
    {
        private List<string> _allDbs = new List<string>();
        private ForestGDBInfo _wkGdbInfo;

        protected bool CreateNewGDB(string keyText)
        {
            if (base._dsAdmin == null)
            {
                return false;
            }
            try
            {
                this.queryAllDBNames();
                if (this.IsGDBExists(this._wkGdbInfo.DBName))
                {
                    TaskResult result = new TaskResult {
                        Msg = "数据库已经存在不需要建立!",
                        Success = true
                    };
                    base.FireProgressChangedEvent(100, result);
                    return true;
                }
                if (base._dsAdmin.IsConnectedUserAdministrator)
                {
                    base._dsAdmin.CreateGeodatabase(this._wkGdbInfo.DBName, this._wkGdbInfo.GdbFileName, (this._wkGdbInfo.GDBSize < 0) ? 0 : this._wkGdbInfo.GDBSize, this._wkGdbInfo.GdbLogFileName, (this._wkGdbInfo.LogSize < 0) ? 0 : this._wkGdbInfo.LogSize);
                    TaskResult result2 = new TaskResult {
                        Msg = "新库建立成功，更新数据库信息...",
                        Success = true
                    };
                    base.FireProgressChangedEvent(20, result2);
                    return this.UpdateGDBToForest(keyText);
                }
                return false;
            }
            catch (Exception exception)
            {
                TaskResult result3 = new TaskResult {
                    Msg = "新库建立失败：" + exception.Message,
                    Success = true
                };
                base.FireProgressChangedEvent(100, result3);
                return false;
            }
        }

        ~NewForestGDBTemplateTask()
        {
            if ((this._allDbs != null) && (this._allDbs.Count >= 1))
            {
                this._allDbs.Clear();
                this._allDbs = null;
            }
            if (base._dsAdmin != null)
            {
                Marshal.ReleaseComObject(base._dsAdmin);
                base._dsAdmin = null;
            }
        }

        private bool IsGDBExists(string gdbName)
        {
            if (base._dsAdmin == null)
            {
                return false;
            }
            this.queryAllDBNames();
            return this._allDbs.Contains(gdbName);
        }

        private int queryAllDBNames()
        {
            if (base._dsAdmin == null)
            {
                return -1;
            }
            try
            {
                this._allDbs.Clear();
                this._allDbs = new List<string>();
                IEnumBSTR geodatabaseNames = base._dsAdmin.GetGeodatabaseNames();
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

        protected bool UpdateGDBToForest(string keyText)
        {
            string str = this._wkGdbInfo.GDBServer.Split(new char[] { '\\' })[0];
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            using (SqlConnection connection = ForestGDBTask.CreateConnection(str, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass, this._wkGdbInfo.DBName))
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
                TaskResult result = new TaskResult {
                    Msg = "空间数据库注册和配置信息更新完成!",
                    Success = true
                };
                base.FireProgressChangedEvent(100, result);
                return true;
            }
        }

        public override object Work(params object[] args)
        {
            base.Work(args);
            if ((args == null) || (args.Length <= 0))
            {
                this.StopTask();
                return null;
            }
            this._wkGdbInfo = args[0] as ForestGDBInfo;
            if (this._wkGdbInfo != null)
            {
                string keyText = string.Empty;
                if (args.Length >= 2)
                {
                    keyText = args[1] as string;
                }
                base.initDSAdmin(this._wkGdbInfo.GDBServer);
                this.CreateNewGDB(keyText);
                TaskResult result = new TaskResult {
                    Msg = "数据导入完成!",
                    Success = true
                };
                base.FireProgressChangedEvent(100, result);
                this.StopTask();
            }
            return null;
        }
    }
}

