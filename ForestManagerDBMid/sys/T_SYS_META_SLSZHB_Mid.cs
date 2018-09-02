using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_SLSZHB")]
public class T_SYS_META_SLSZHB_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "SORTID", Index = 1)]
public long SORTID { get; set; }
//字段别名:
[TDDBProperty(Column = "CNAME", Index = 2)]
public string CNAME { get; set; }
//字段别名:
[TDDBProperty(Column = "MERGERULE", Index = 3)]
public string MERGERULE { get; set; }
}
}
