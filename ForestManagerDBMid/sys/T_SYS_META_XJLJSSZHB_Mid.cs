using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_XJLJSSZHB")]
public class T_SYS_META_XJLJSSZHB_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "JSLX", Index = 1)]
public double JSLX { get; set; }
//字段别名:
[TDDBProperty(Column = "SZZNAME", Index = 2)]
public string SZZNAME { get; set; }
//字段别名:
[TDDBProperty(Column = "SZHBBDS", Index = 3)]
public string SZHBBDS { get; set; }
}
}
