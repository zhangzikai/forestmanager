using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "BASE_P_LINBAN_10K")]
public class BASE_P_LINBAN_10K_Mid
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
//字段别名:乡镇
[TDDBProperty(Column = "XIANG", Index = 4)]
public string XIANG { get; set; }
//字段别名:村
[TDDBProperty(Column = "CUN", Index = 5)]
public string CUN { get; set; }
//字段别名:林班
[TDDBProperty(Column = "LIN_BAN", Index = 6)]
public string LIN_BAN { get; set; }
}
}
