using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "BASE_L_XIAN_10K")]
public class BASE_L_XIAN_10K_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
}
}
