using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_FLOW_AUTHOR")]
public class T_SYS_FLOW_AUTHOR_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:权限编号
[TDDBProperty(Column = "AUTHOR_ID", Index = 1)]
public long AUTHOR_ID { get; set; }
//字段别名:权限名称
[TDDBProperty(Column = "AUTHOR_NAME", Index = 2)]
public string AUTHOR_NAME { get; set; }
//字段别名:权限说明
[TDDBProperty(Column = "AUTHOR_NOTE", Index = 3)]
public string AUTHOR_NOTE { get; set; }
//字段别名:系统专题
[TDDBProperty(Column = "SYSTEM_ZT", Index = 4)]
public string SYSTEM_ZT { get; set; }
}
}
