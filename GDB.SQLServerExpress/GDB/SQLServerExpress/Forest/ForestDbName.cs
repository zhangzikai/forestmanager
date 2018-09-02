namespace GDB.SQLServerExpress.Forest
{
    using System;
    using System.Runtime.CompilerServices;

    public class ForestDbName
    {
        private string _dbName = string.Empty;

        public string AliasName { get; set; }

        public int ConnectedUsers { get; set; }

        public int DataYear { get; set; }

        public string DBName
        {
            get
            {
                if (!string.IsNullOrEmpty(this._dbName))
                {
                    return this._dbName;
                }
                return string.Format("FORDATA_{0}_{1}", string.IsNullOrEmpty(this.GBCode) ? "00" : this.GBCode, (this.DataYear <= 0) ? 0x7dc : this.DataYear);
            }
            set
            {
                this._dbName = value;
            }
        }

        public string GBCode { get; set; }
    }
}

