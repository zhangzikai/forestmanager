using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "T_ZT_CF_SZ_JC_TO_CZ")]
public class T_ZT_CF_SZ_JC_TO_CZ_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "JCSZ", Index = 1)]
public string JCSZ { get; set; }
//字段别名:
[TDDBProperty(Column = "CJSZ", Index = 2)]
public string CJSZ { get; set; }
}
}
