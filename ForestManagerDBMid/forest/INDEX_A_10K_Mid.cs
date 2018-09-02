using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "INDEX_A_10K")]
public class INDEX_A_10K_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:旧图幅号
[TDDBProperty(Column = "旧图幅号", Index = 1)]
public string 旧图幅号 { get; set; }
//字段别名:新图幅号
[TDDBProperty(Column = "新图幅号", Index = 2)]
public string 新图幅号 { get; set; }
//字段别名:地名
[TDDBProperty(Column = "地名", Index = 3)]
public string 地名 { get; set; }
//字段别名:带号
[TDDBProperty(Column = "带号", Index = 4)]
public string 带号 { get; set; }
}
}
