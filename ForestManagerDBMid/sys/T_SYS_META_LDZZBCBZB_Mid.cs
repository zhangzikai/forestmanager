using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_LDZZBCBZB")]
public class T_SYS_META_LDZZBCBZB_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:
[TDDBProperty(Column = "BCLXCODE", Index = 1)]
public string BCLXCODE { get; set; }
//字段别名:
[TDDBProperty(Column = "BCLXNAME", Index = 2)]
public string BCLXNAME { get; set; }
//字段别名:
[TDDBProperty(Column = "BCDJ", Index = 3)]
public double BCDJ { get; set; }
//字段别名:
[TDDBProperty(Column = "TJBDS", Index = 4)]
public string TJBDS { get; set; }
//字段别名:
[TDDBProperty(Column = "XIAN", Index = 5)]
public string XIAN { get; set; }
//字段别名:
[TDDBProperty(Column = "BCBZJLND", Index = 6)]
public string BCBZJLND { get; set; }
//字段别名:
[TDDBProperty(Column = "BZ", Index = 7)]
public string BZ { get; set; }
//字段别名:
[TDDBProperty(Column = "XMMC", Index = 8)]
public string XMMC { get; set; }
}
}
