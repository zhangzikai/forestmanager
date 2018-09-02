namespace GX_DBUpdate.vPojo
{
    using GX_DB_INFO.Properties;
    using GX_DBUpdate.vUtils;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class vDbInfoTable
    {
        private readonly ServerConnection _dbConn;
        public static readonly string TBNAME = "T_SYS_DB_INFO";

        public event VersionUpdateMessageHandler OnUpdateMessage;

        public vDbInfoTable(ServerConnection svConn)
        {
            this._dbConn = svConn;
        }

        private string GetDbVersion(Database db)
        {
            if ((db == null) || !db.IsAccessible)
            {
                return string.Empty;
            }
            try
            {
                if (db.Tables[TBNAME] == null)
                {
                    return "0";
                }
                return (db.ExecuteWithResults(Resources.GETVERSION).Tables[0].Rows[0][0] as string);
            }
            catch (Exception)
            {
                return "0";
            }
        }

        private List<string> GetVersions()
        {
            string location = base.GetType().Assembly.Location;
            DirectoryInfo info = new DirectoryInfo(location);
            FileInfo[] files = new DirectoryInfo(location.Replace(info.Name, "") + "UQL" + Path.DirectorySeparatorChar).GetFiles();
            string str2 = ".UQL,.SQL";
            foreach (FileInfo info3 in files)
            {
                if (!string.IsNullOrEmpty(info3.Extension) && (str2.IndexOf(info3.Extension.ToUpper()) >= 0))
                {
                    string str3 = info3.Name.Replace(info3.Extension, "").ToUpper();
                }
            }
            return null;
        }

        private Table initVersion(Database db)
        {
            Table table = db.Tables[TBNAME];
            if (table != null)
            {
                return table;
            }
            FileInfo versionFile = vPathUtil.GetVersionFile("V0TOV1");
            if (versionFile == null)
            {
                db.ExecuteNonQuery(Resources.V0TOV1);
            }
            else
            {
                string sqlCommand = versionFile.OpenText().ReadToEnd();
                db.ExecuteNonQuery(sqlCommand);
            }
            if (this.OnUpdateMessage != null)
            {
                this.OnUpdateMessage(this, "已将数据升级为 版本 1 ", 0);
            }
            db.Refresh();
            return db.Tables[TBNAME];
        }

        public bool UpdateVersion(string dbName)
        {
            Server server = new Server(this._dbConn);
            Database db = server.Databases[dbName];
            if (db == null)
            {
                return false;
            }
            this.initVersion(db);
            string dbVersion = this.GetDbVersion(db);
            ArrayList versionDirs = vPathUtil.GetVersionDirs();
            if ((versionDirs == null) || (versionDirs.Count <= 0))
            {
                return false;
            }
            int num = 0;
            foreach (DirectoryInfo info in versionDirs)
            {
                string str2 = info.Name.ToUpper();
                if (!str2.Contains("V0TOV1"))
                {
                    string str3 = str2.Substring(0, str2.IndexOf("TO"));
                    string str4 = str2.Substring(str2.IndexOf("TO") + "TO".Length);
                    if (!string.IsNullOrEmpty(str3) && !string.IsNullOrEmpty(str4))
                    {
                        int num2;
                        int num3;
                        str3 = str3.Replace("V", "");
                        if ((int.TryParse(str4.Replace("V", ""), out num2) && int.TryParse(dbVersion, out num3)) && (num3 < num2))
                        {
                            ArrayList versionFiles = vPathUtil.GetVersionFiles(info);
                            if ((versionFiles != null) && (versionFiles.Count >= 1))
                            {
                                foreach (FileInfo info2 in versionFiles)
                                {
                                    string sqlCommand = info2.OpenText().ReadToEnd();
                                    try
                                    {
                                        db.ExecuteNonQuery(sqlCommand);
                                    }
                                    catch (Exception exception)
                                    {
                                        if (DialogResult.Yes == MessageBox.Show("执行升级操作时发生错误:" + exception.Message + "\n 请与林勘院联系!", "数据库升级错误", MessageBoxButtons.YesNo))
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        num++;
                        str2.Replace("TO", "升级为");
                        if (this.OnUpdateMessage != null)
                        {
                            this.OnUpdateMessage(this, "版本" + str2 + "更新完成!", (num / versionDirs.Count) * 100);
                        }
                    }
                }
            }
            return true;
        }

        public delegate void VersionUpdateMessageHandler(object sender, string msg, int step);
    }
}

