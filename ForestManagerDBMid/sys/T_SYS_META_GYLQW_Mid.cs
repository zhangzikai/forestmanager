using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_GYLQW")]
public class T_SYS_META_GYLQW_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "XH", Index = 1)]
public short XH { get; set; }
//字段别名:
[TDDBProperty(Column = "DM", Index = 2)]
public string DM { get; set; }
//字段别名:
[TDDBProperty(Column = "STQW", Index = 3)]
public string STQW { get; set; }
//字段别名:
[TDDBProperty(Column = "MC", Index = 4)]
public string MC { get; set; }
}
}
