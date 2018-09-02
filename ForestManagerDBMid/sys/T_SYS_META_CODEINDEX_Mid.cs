using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_CODEINDEX")]
public class T_SYS_META_CODEINDEX_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:类型
[TDDBProperty(Column = "TYPE", Index = 1)]
public string TYPE { get; set; }
//字段别名:代码
[TDDBProperty(Column = "CODE", Index = 2)]
public string CODE { get; set; }
//字段别名:域名称
[TDDBProperty(Column = "DOMAINNAME", Index = 3)]
public string DOMAINNAME { get; set; }
}
}
