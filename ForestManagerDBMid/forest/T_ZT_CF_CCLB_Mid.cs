using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "T_ZT_CF_CCLB")]
public class T_ZT_CF_CCLB_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:树种
[TDDBProperty(Column = "SZ", Index = 1)]
public string SZ { get; set; }
//字段别名:径阶
[TDDBProperty(Column = "JJ", Index = 2)]
public short JJ { get; set; }
//字段别名:大材出材率
[TDDBProperty(Column = "D", Index = 3)]
public double D { get; set; }
//字段别名:中材出材率
[TDDBProperty(Column = "Z", Index = 4)]
public double Z { get; set; }
//字段别名:小材出材率
[TDDBProperty(Column = "X", Index = 5)]
public double X { get; set; }
//字段别名:合计出材率
[TDDBProperty(Column = "HJ", Index = 6)]
public double HJ { get; set; }
//字段别名:短小材出材率
[TDDBProperty(Column = "DX", Index = 7)]
public double DX { get; set; }
//字段别名:树皮出材率
[TDDBProperty(Column = "SP", Index = 8)]
public double SP { get; set; }
}
}
