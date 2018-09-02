using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "T_ZT_CF_SZ_JC_TO_CC")]
public class T_ZT_CF_SZ_JC_TO_CC_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "JCSZ", Index = 1)]
public string JCSZ { get; set; }
//字段别名:
[TDDBProperty(Column = "CCSZ", Index = 2)]
public string CCSZ { get; set; }
}
}
