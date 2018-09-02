using System;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "T_STAT_REPORT")]
    public class T_STAT_REPORT_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:
        [TDDBProperty(Column = "Theme", Index = 1)]
        public string Theme { get; set; }
        //字段别名:
        [TDDBProperty(Column = "ReportID", Index = 2)]
        public int ReportID { get; set; }
        //字段别名:
        [TDDBProperty(Column = "ReportName", Index = 3)]
        public string ReportName { get; set; }
        //字段别名:
        [TDDBProperty(Column = "DataTable", Index = 4)]
        public string DataTable { get; set; }
        //字段别名:
        [TDDBProperty(Column = "TableSql", Index = 5)]
        public string TableSql { get; set; }
        //字段别名:
        [TDDBProperty(Column = "StoredProcedure", Index = 6)]
        public string StoredProcedure { get; set; }
        //字段别名:
        [TDDBProperty(Column = "StoredProcedureSql", Index = 7)]
        public string StoredProcedureSql { get; set; }
        //字段别名:
        [TDDBProperty(Column = "UseStoredProcedure", Index = 8)]
        public string UseStoredProcedure { get; set; }
        //字段别名:
        [TDDBProperty(Column = "StaticSQL", Index = 9)]
        public string StaticSQL { get; set; }
        //字段别名:
        [TDDBProperty(Column = "StartIndex", Index = 10)]
        public int StartIndex { get; set; }
        //字段别名:
        [TDDBProperty(Column = "GroupIndex", Index = 11)]
        public string GroupIndex { get; set; }
        //字段别名:
        [TDDBProperty(Column = "DtColIndex", Index = 12)]
        public int DtColIndex { get; set; }
        //字段别名:
        [TDDBProperty(Column = "reportyear", Index = 13)]
        public int reportyear { get; set; }
        //字段别名:
        [TDDBProperty(Column = "IsShow", Index = 14)]
        public int IsShow { get; set; }
        //字段别名:
        [TDDBProperty(Column = "MergeColIndex", Index = 15)]
        public string MergeColIndex { get; set; }
    }
}
