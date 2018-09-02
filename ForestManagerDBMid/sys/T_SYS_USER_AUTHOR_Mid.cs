using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_USER_AUTHOR")]
public class T_SYS_USER_AUTHOR_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "USER_ID", Index = 1)]
public long USER_ID { get; set; }
//字段别名:
[TDDBProperty(Column = "AUTHOR_ID", Index = 2)]
public int AUTHOR_ID { get; set; }
}
}
