using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "ZT_L_LDZZ_2016")]
public class ZT_L_LDZZ_2016_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:项目编号
[TDDBProperty(Column = "XMBH", Index = 1)]
public string XMBH { get; set; }
//字段别名:序号
[TDDBProperty(Column = "XH", Index = 2)]
public string XH { get; set; }
}
}
