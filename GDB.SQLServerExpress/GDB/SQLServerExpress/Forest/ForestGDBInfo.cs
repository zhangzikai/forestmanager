namespace GDB.SQLServerExpress.Forest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class ForestGDBInfo : ForestDbName
    {
        private string _version = "dbo.Default";
        private string _yearFrstPrefix = "FOR_XIAOBAN_";
        private List<string> updateMetaInfos = new List<string>(new string[] { "ZT_CF", "ZT_ZL", "ZT_LYAJ", "ZT_LDZZ", "ZT_HZ", "ZT_ZH", "ZT_YGJC", "FOR_XBBH" });
        public const string WKGDB_KEY = "sdeworkgroup,100,sdeworkgroup,01-jan-2030,IE7XTNBJ3Y4JYJT15089";

        public bool IsDataSetNeedReName(string dsName)
        {
            if (string.IsNullOrEmpty(this.ReNameDatasets))
            {
                return false;
            }
            return this.ReNameDatasets.Contains(dsName);
        }

        public string ForestXbNamePart
        {
            get
            {
                return this._yearFrstPrefix;
            }
            set
            {
                this._yearFrstPrefix = value;
            }
        }

        public string GDBDir { get; set; }

        public string GdbFileName
        {
            get
            {
                return string.Concat(new object[] { this.GDBDir, Path.DirectorySeparatorChar, base.DBName, ".MDF" });
            }
        }

        public string GdbLogFileName
        {
            get
            {
                return string.Concat(new object[] { this.GDBDir, Path.DirectorySeparatorChar, base.DBName, ".LDF" });
            }
        }

        public string GDBServer
        {
            get
            {
                return string.Format(@"{0}\{1}", this.ServerName, this.IntanceName);
            }
        }

        public int GDBSize { get; set; }

        public string IntanceName { get; set; }

        public int LogSize { get; set; }

        public string ReNameDatasets { get; set; }

        public string ServerName { get; set; }

        public List<string> UpdateMetaInfos
        {
            get
            {
                return this.updateMetaInfos;
            }
            set
            {
                this.updateMetaInfos = value;
            }
        }

        public string UserName { get; set; }

        public string UserPass { get; set; }

        public string Version
        {
            get
            {
                return this._version;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._version = value;
                }
            }
        }
    }
}

