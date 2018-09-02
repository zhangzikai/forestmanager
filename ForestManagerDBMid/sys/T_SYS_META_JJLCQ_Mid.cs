using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_JJLCQ")]
public class T_SYS_META_JJLCQ_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "LB", Index = 1)]
public string LB { get; set; }
//字段别名:
[TDDBProperty(Column = "YOU_SHI_SZ", Index = 2)]
public string YOU_SHI_SZ { get; set; }
//字段别名:
[TDDBProperty(Column = "SZMC", Index = 3)]
public string SZMC { get; set; }
//字段别名:
[TDDBProperty(Column = "A1", Index = 4)]
public short A1 { get; set; }
//字段别名:
[TDDBProperty(Column = "A2", Index = 5)]
public short A2 { get; set; }
//字段别名:
[TDDBProperty(Column = "B1", Index = 6)]
public short B1 { get; set; }
//字段别名:
[TDDBProperty(Column = "B2", Index = 7)]
public short B2 { get; set; }
//字段别名:
[TDDBProperty(Column = "C1", Index = 8)]
public short C1 { get; set; }
//字段别名:
[TDDBProperty(Column = "C2", Index = 9)]
public short C2 { get; set; }
//字段别名:
[TDDBProperty(Column = "D", Index = 10)]
public short D { get; set; }
}
}
