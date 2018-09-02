using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_LJLZ")]
public class T_SYS_META_LJLZ_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "NAME", Index = 1)]
public string NAME { get; set; }
//字段别名:
[TDDBProperty(Column = "LIN_ZHONG", Index = 2)]
public string LIN_ZHONG { get; set; }
//字段别名:
[TDDBProperty(Column = "QI_YUAN", Index = 3)]
public string QI_YUAN { get; set; }
//字段别名:
[TDDBProperty(Column = "DI_LEI", Index = 4)]
public string DI_LEI { get; set; }
//字段别名:
[TDDBProperty(Column = "YOU_SHI_SZ", Index = 5)]
public string YOU_SHI_SZ { get; set; }
//字段别名:
[TDDBProperty(Column = "LJQX", Index = 6)]
public long LJQX { get; set; }
//字段别名:
[TDDBProperty(Column = "ZFNL", Index = 7)]
public long ZFNL { get; set; }
//字段别名:
[TDDBProperty(Column = "A1", Index = 8)]
public long A1 { get; set; }
//字段别名:
[TDDBProperty(Column = "A2", Index = 9)]
public long A2 { get; set; }
//字段别名:
[TDDBProperty(Column = "B1", Index = 10)]
public long B1 { get; set; }
//字段别名:
[TDDBProperty(Column = "B2", Index = 11)]
public long B2 { get; set; }
//字段别名:
[TDDBProperty(Column = "C1", Index = 12)]
public long C1 { get; set; }
//字段别名:
[TDDBProperty(Column = "C2", Index = 13)]
public long C2 { get; set; }
//字段别名:
[TDDBProperty(Column = "D1", Index = 14)]
public long D1 { get; set; }
//字段别名:
[TDDBProperty(Column = "D2", Index = 15)]
public long D2 { get; set; }
//字段别名:
[TDDBProperty(Column = "E", Index = 16)]
public long E { get; set; }
}
}
