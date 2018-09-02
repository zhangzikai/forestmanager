namespace GDB.SQLServerExpress.Forest
{
    using System;
    using System.Runtime.CompilerServices;

    public class ForestMdfInfo
    {
        public string DataFileName { get; set; }

        public string DataName { get; set; }

        public int DataSize { get; set; }

        public bool IStatus { get; set; }

        public string LogFileName { get; set; }

        public string LogName { get; set; }

        public int LogSize { get; set; }

        public string Satus { get; set; }
    }
}

