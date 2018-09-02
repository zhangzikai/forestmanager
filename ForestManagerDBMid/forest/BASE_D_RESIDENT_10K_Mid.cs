using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "BASE_D_RESIDENT_10K")]
public class BASE_D_RESIDENT_10K_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:代码
[TDDBProperty(Column = "CODE", Index = 1)]
public string CODE { get; set; }
//字段别名:名称
[TDDBProperty(Column = "NAME", Index = 2)]
public string NAME { get; set; }
//字段别名:驻地类型
[TDDBProperty(Column = "TYPE", Index = 3)]
public string TYPE { get; set; }
}
}
