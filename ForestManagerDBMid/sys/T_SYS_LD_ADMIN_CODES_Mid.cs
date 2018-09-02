using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_LD_ADMIN_CODES")]
public class T_SYS_LD_ADMIN_CODES_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:父代码
[TDDBProperty(Column = "PCODE", Index = 1)]
public string PCODE { get; set; }
//字段别名:代码
[TDDBProperty(Column = "CCODE", Index = 2)]
public string CCODE { get; set; }
//字段别名:名称
[TDDBProperty(Column = "CNAME", Index = 3)]
public string CNAME { get; set; }
//字段别名:类型
[TDDBProperty(Column = "CTYPE", Index = 4)]
public string CTYPE { get; set; }
//字段别名:简称
[TDDBProperty(Column = "CNAM", Index = 5)]
public string CNAM { get; set; }
}
}
