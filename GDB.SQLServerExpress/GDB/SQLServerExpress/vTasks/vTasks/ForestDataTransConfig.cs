namespace GDB.SQLServerExpress.vTasks.vTasks
{
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.Runtime.CompilerServices;

    public class ForestDataTransConfig
    {
        public esriDatasetType EsriType { get; set; }

        public string SrcDBName { get; set; }

        public string SrcType { get; set; }

        public string TargetDbName { get; set; }

        public string Uid { get; set; }
    }
}

