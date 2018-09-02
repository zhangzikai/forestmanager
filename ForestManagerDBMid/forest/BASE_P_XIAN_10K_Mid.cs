using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "BASE_P_XIAN_10K")]
public class BASE_P_XIAN_10K_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:省
[TDDBProperty(Column = "SHENG", Index = 1)]
public string SHENG { get; set; }
//字段别名:市
[TDDBProperty(Column = "SHI", Index = 2)]
public string SHI { get; set; }
//字段别名:县
[TDDBProperty(Column = "XIAN", Index = 3)]
public string XIAN { get; set; }
}
}
