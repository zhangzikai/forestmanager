using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "ZT_HZ_2016")]
public class ZT_HZ_2016_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:省
[TDDBProperty(Column = "SHENG", Index = 1)]
public string SHENG { get; set; }
//字段别名:市
[TDDBProperty(Column = "SHI", Index = 2)]
public string SHI { get; set; }
//字段别名:区县
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
//字段别名:图斑(小班)
[TDDBProperty(Column = "XIAO_BAN", Index = 7)]
public string XIAO_BAN { get; set; }
//字段别名:细斑
[TDDBProperty(Column = "XI_BAN", Index = 8)]
public string XI_BAN { get; set; }
//字段别名:前期土地权属
[TDDBProperty(Column = "Q_LD_QS", Index = 9)]
public string Q_LD_QS { get; set; }
//字段别名:土地权属
[TDDBProperty(Column = "LD_QS", Index = 10)]
public string LD_QS { get; set; }
//字段别名:土地使用权
[TDDBProperty(Column = "TDJYQ", Index = 11)]
public string TDJYQ { get; set; }
//字段别名:林木所有权
[TDDBProperty(Column = "LMSYQ", Index = 12)]
public string LMSYQ { get; set; }
//字段别名:林木使用权
[TDDBProperty(Column = "LMJYQ", Index = 13)]
public string LMJYQ { get; set; }
//字段别名:面积
[TDDBProperty(Column = "MIAN_JI", Index = 14)]
public double MIAN_JI { get; set; }
//字段别名:前期地类
[TDDBProperty(Column = "Q_DI_LEI", Index = 15)]
public string Q_DI_LEI { get; set; }
//字段别名:地类
[TDDBProperty(Column = "DI_LEI", Index = 16)]
public string DI_LEI { get; set; }
//字段别名:前期林种
[TDDBProperty(Column = "Q_LIN_ZHONG", Index = 17)]
public string Q_LIN_ZHONG { get; set; }
//字段别名:林种
[TDDBProperty(Column = "LIN_ZHONG", Index = 18)]
public string LIN_ZHONG { get; set; }
//字段别名:起源
[TDDBProperty(Column = "QI_YUAN", Index = 19)]
public string QI_YUAN { get; set; }
//字段别名:前期森林类别
[TDDBProperty(Column = "Q_SEN_LB", Index = 20)]
public string Q_SEN_LB { get; set; }
//字段别名:森林类别
[TDDBProperty(Column = "SEN_LIN_LB", Index = 21)]
public string SEN_LIN_LB { get; set; }
//字段别名:变化原因
[TDDBProperty(Column = "BHYY", Index = 22)]
public string BHYY { get; set; }
//字段别名:郁闭度
[TDDBProperty(Column = "YU_BI_DU", Index = 23)]
public double YU_BI_DU { get; set; }
//字段别名:优势树种
[TDDBProperty(Column = "YOU_SHI_SZ", Index = 24)]
public string YOU_SHI_SZ { get; set; }
//字段别名:灾害类型
[TDDBProperty(Column = "DISPE", Index = 25)]
public string DISPE { get; set; }
//字段别名:灾害等级
[TDDBProperty(Column = "DISASTER_C", Index = 26)]
public string DISASTER_C { get; set; }
//字段别名:灾害面积
[TDDBProperty(Column = "ZHMJ", Index = 27)]
public double ZHMJ { get; set; }
//字段别名:损失蓄积
[TDDBProperty(Column = "SUNSHIXJ", Index = 28)]
public int SUNSHIXJ { get; set; }
//字段别名:保留蓄积
[TDDBProperty(Column = "BLXJ", Index = 29)]
public int BLXJ { get; set; }
//字段别名:更新时间
[TDDBProperty(Column = "GXSJ", Index = 30)]
public string GXSJ { get; set; }
//字段别名:平均年龄
[TDDBProperty(Column = "PINGJUN_NL", Index = 31)]
public double PINGJUN_NL { get; set; }
//字段别名:龄组
[TDDBProperty(Column = "LING_ZU", Index = 32)]
public string LING_ZU { get; set; }
//字段别名:损失株数（万株）
[TDDBProperty(Column = "SS_ZS", Index = 33)]
public double SS_ZS { get; set; }
//字段别名:火灾编号
[TDDBProperty(Column = "FIRE_NO", Index = 34)]
public string FIRE_NO { get; set; }
//字段别名:火灾等级
[TDDBProperty(Column = "HZDJ", Index = 35)]
public string HZDJ { get; set; }
//字段别名:火灾原因
[TDDBProperty(Column = "HZYY", Index = 36)]
public string HZYY { get; set; }
//字段别名:起火时间
[TDDBProperty(Column = "QHSJ", Index = 37)]
public DateTime QHSJ { get; set; }
}
}
