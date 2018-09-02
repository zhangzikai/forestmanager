using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_FLOW_DEPT")]
public class T_SYS_FLOW_DEPT_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:角色编号
[TDDBProperty(Column = "DEPT_ID", Index = 1)]
public long DEPT_ID { get; set; }
//字段别名:角色名称
[TDDBProperty(Column = "DEPT_NAME", Index = 2)]
public string DEPT_NAME { get; set; }
//字段别名:角色说明
[TDDBProperty(Column = "DEPT_NOTE", Index = 3)]
public string DEPT_NOTE { get; set; }
}
}
