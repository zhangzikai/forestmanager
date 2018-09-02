using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "BASE_L_ROAD_10K")]
public class BASE_L_ROAD_10K_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:道路名称
[TDDBProperty(Column = "NAME", Index = 1)]
public string NAME { get; set; }
//字段别名:道路类型
[TDDBProperty(Column = "TYPE", Index = 2)]
public string TYPE { get; set; }
}
}
