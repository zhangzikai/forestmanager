namespace GDB.SQLServerExpress.vTasks.Forest
{
    using System;
    using System.Runtime.CompilerServices;

    public class ForestDBServerInfo
    {
        public string GeoDBInstance
        {
            get
            {
                return string.Format(@"{0}\{1}", this.ServerName, this.InstanceName);
            }
        }

        public string InstanceName { get; set; }

        public string ServerName { get; set; }

        public string UserName { get; set; }

        public string UserPass { get; set; }
    }
}

