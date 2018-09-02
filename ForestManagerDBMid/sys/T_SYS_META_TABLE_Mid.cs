using System;
using td.db.orm;

namespace td.db.mid.sys
{
[TDDBRecord(Table = "T_SYS_META_TABLE")]
public class T_SYS_META_TABLE_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:序号
[TDDBProperty(Column = "SNO", Index = 1)]
public string SNO { get; set; }
//字段别名:表编号
[TDDBProperty(Column = "TAB_ID", Index = 2)]
public string TAB_ID { get; set; }
//字段别名:表名称
[TDDBProperty(Column = "TAB_NAME", Index = 3)]
public string TAB_NAME { get; set; }
//字段别名:表别名
[TDDBProperty(Column = "TAB_ALIA", Index = 4)]
public string TAB_ALIA { get; set; }
//字段别名:表类型
[TDDBProperty(Column = "TAB_TYPE", Index = 5)]
public string TAB_TYPE { get; set; }
//字段别名:所属专题
[TDDBProperty(Column = "TAB_THE", Index = 6)]
public string TAB_THE { get; set; }
//字段别名:表关联类别
[TDDBProperty(Column = "LINKTYPE", Index = 7)]
public string LINKTYPE { get; set; }
//字段别名:额外信息
[TDDBProperty(Column = "TAB_EXT", Index = 8)]
public string TAB_EXT { get; set; }
//字段别名:表目录
[TDDBProperty(Column = "TAB_CAT", Index = 9)]
public string TAB_CAT { get; set; }
//字段别名:是否有关联表
[TDDBProperty(Column = "ISLINK", Index = 10)]
public string ISLINK { get; set; }
//字段别名:是否为代码表
[TDDBProperty(Column = "ISCTAB", Index = 11)]
public string ISCTAB { get; set; }
//字段别名:是否为元数据表
[TDDBProperty(Column = "ISMTAB", Index = 12)]
public string ISMTAB { get; set; }
}
}
