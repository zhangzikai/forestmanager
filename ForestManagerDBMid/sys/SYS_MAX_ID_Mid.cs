using System;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "SYS_MAX_ID")]
    public class SYS_MAX_ID_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:
        [TDDBProperty(Column = "MAX_TYPE", Index = 1)]
        public string MAX_TYPE { get; set; }
        //字段别名:
        [TDDBProperty(Column = "MAX_ID", Index = 2)]
        public long MAX_ID { get; set; }
        //字段别名:
        [TDDBProperty(Column = "TYPE_NAME", Index = 3)]
        public string TYPE_NAME { get; set; }
    }
}
