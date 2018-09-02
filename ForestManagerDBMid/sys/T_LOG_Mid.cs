using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_LOG")]
public class T_LOG_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "USER_NAME", Index = 1)]
public string USER_NAME { get; set; }
//字段别名:
[TDDBProperty(Column = "OPERATE", Index = 2)]
public string OPERATE { get; set; }
//字段别名:
[TDDBProperty(Column = "LOG_TIME", Index = 3)]
public DateTime LOG_TIME { get; set; }
//字段别名:
[TDDBProperty(Column = "REMARK", Index = 4)]
public string REMARK { get; set; }
//字段别名:
[TDDBProperty(Column = "SYSTEM", Index = 5)]
public string SYSTEM { get; set; }
}
}
