using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_GROWTHMODEL")]
public class T_SYS_META_GROWTHMODEL_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "MODELBH", Index = 1)]
public long MODELBH { get; set; }
//字段别名:
[TDDBProperty(Column = "XIANCODE", Index = 2)]
public string XIANCODE { get; set; }
//字段别名:
[TDDBProperty(Column = "XIANNAME", Index = 3)]
public string XIANNAME { get; set; }
//字段别名:
[TDDBProperty(Column = "JLSJ", Index = 4)]
public string JLSJ { get; set; }
//字段别名:
[TDDBProperty(Column = "MODELTYPE", Index = 5)]
public string MODELTYPE { get; set; }
//字段别名:
[TDDBProperty(Column = "SZZNAME", Index = 6)]
public string SZZNAME { get; set; }
//字段别名:
[TDDBProperty(Column = "SZZGBBDS", Index = 7)]
public string SZZGBBDS { get; set; }
//字段别名:
[TDDBProperty(Column = "PJHGS", Index = 8)]
public string PJHGS { get; set; }
//字段别名:
[TDDBProperty(Column = "PJDGS", Index = 9)]
public string PJDGS { get; set; }
//字段别名:
[TDDBProperty(Column = "MGQXJJSGS", Index = 10)]
public string MGQXJJSGS { get; set; }
//字段别名:
[TDDBProperty(Column = "SSXJXS", Index = 11)]
public double SSXJXS { get; set; }
//字段别名:
[TDDBProperty(Column = "BZ", Index = 12)]
public string BZ { get; set; }
}
}
