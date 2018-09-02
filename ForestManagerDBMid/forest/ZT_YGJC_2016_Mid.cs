using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "ZT_YGJC_2016")]
public class ZT_YGJC_2016_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:遥感判读编号
[TDDBProperty(Column = "NO_TB", Index = 1)]
public string NO_TB { get; set; }
//字段别名:省
[TDDBProperty(Column = "SHENG", Index = 2)]
public string SHENG { get; set; }
//字段别名:县
[TDDBProperty(Column = "XIAN", Index = 3)]
public string XIAN { get; set; }
//字段别名:乡镇
[TDDBProperty(Column = "XIANG", Index = 4)]
public string XIANG { get; set; }
//字段别名:村
[TDDBProperty(Column = "CUN", Index = 5)]
public string CUN { get; set; }
//字段别名:林业局（场）
[TDDBProperty(Column = "LIN_YE_JU", Index = 6)]
public string LIN_YE_JU { get; set; }
//字段别名:林场（分场）
[TDDBProperty(Column = "LIN_CHANG", Index = 7)]
public string LIN_CHANG { get; set; }
//字段别名:林班
[TDDBProperty(Column = "LIN_BAN", Index = 8)]
public string LIN_BAN { get; set; }
//字段别名:判读地类
[TDDBProperty(Column = "PAN_DILEI", Index = 9)]
public string PAN_DILEI { get; set; }
//字段别名:备注
[TDDBProperty(Column = "BEIZU", Index = 10)]
public string BEIZU { get; set; }
//字段别名:面积
[TDDBProperty(Column = "MIAN_JI", Index = 11)]
public double MIAN_JI { get; set; }
//字段别名:地貌
[TDDBProperty(Column = "DI_MAO", Index = 12)]
public string DI_MAO { get; set; }
//字段别名:坡向
[TDDBProperty(Column = "PO_XIANG", Index = 13)]
public string PO_XIANG { get; set; }
//字段别名:坡位
[TDDBProperty(Column = "PO_WEI", Index = 14)]
public string PO_WEI { get; set; }
//字段别名:坡度
[TDDBProperty(Column = "PO_DU", Index = 15)]
public string PO_DU { get; set; }
//字段别名:土壤类型
[TDDBProperty(Column = "TU_RANG_LX", Index = 16)]
public string TU_RANG_LX { get; set; }
//字段别名:土层厚度
[TDDBProperty(Column = "TU_CENG_HD", Index = 17)]
public int TU_CENG_HD { get; set; }
//字段别名:林带长度
[TDDBProperty(Column = "LD_CD", Index = 18)]
public double LD_CD { get; set; }
//字段别名:林带宽度
[TDDBProperty(Column = "LD_KD", Index = 19)]
public double LD_KD { get; set; }
//字段别名:交通区位
[TDDBProperty(Column = "KE_JI_DU", Index = 20)]
public string KE_JI_DU { get; set; }
//字段别名:地类
[TDDBProperty(Column = "DI_LEI", Index = 21)]
public string DI_LEI { get; set; }
//字段别名:林地质量等级
[TDDBProperty(Column = "ZL_DJ", Index = 22)]
public string ZL_DJ { get; set; }
//字段别名:土地权属
[TDDBProperty(Column = "LD_QS", Index = 23)]
public string LD_QS { get; set; }
//字段别名:林种
[TDDBProperty(Column = "LIN_ZHONG", Index = 24)]
public string LIN_ZHONG { get; set; }
//字段别名:森林类别
[TDDBProperty(Column = "SEN_LIN_LB", Index = 25)]
public string SEN_LIN_LB { get; set; }
//字段别名:工程类别
[TDDBProperty(Column = "G_CHENG_LB", Index = 26)]
public string G_CHENG_LB { get; set; }
//字段别名:起源
[TDDBProperty(Column = "QI_YUAN", Index = 27)]
public string QI_YUAN { get; set; }
//字段别名:优势树种
[TDDBProperty(Column = "YOU_SHI_SZ", Index = 28)]
public string YOU_SHI_SZ { get; set; }
//字段别名:郁闭度/覆盖度
[TDDBProperty(Column = "YU_BI_DU", Index = 29)]
public double YU_BI_DU { get; set; }
//字段别名:龄组
[TDDBProperty(Column = "LING_ZU", Index = 30)]
public string LING_ZU { get; set; }
//字段别名:平均胸径
[TDDBProperty(Column = "PINGJUN_XJ", Index = 31)]
public double PINGJUN_XJ { get; set; }
//字段别名:平均年龄
[TDDBProperty(Column = "PINGJUN_NL", Index = 32)]
public int PINGJUN_NL { get; set; }
//字段别名:平均树高
[TDDBProperty(Column = "PINGJUN_SG", Index = 33)]
public double PINGJUN_SG { get; set; }
//字段别名:每公顷断面
[TDDBProperty(Column = "PINGJUN_DM", Index = 34)]
public double PINGJUN_DM { get; set; }
//字段别名:公顷蓄积(活立木)
[TDDBProperty(Column = "HUO_LMGQXJ", Index = 35)]
public int HUO_LMGQXJ { get; set; }
//字段别名:灾害类型
[TDDBProperty(Column = "DISPE", Index = 36)]
public string DISPE { get; set; }
//字段别名:灾害等级
[TDDBProperty(Column = "DISASTER_C", Index = 37)]
public string DISASTER_C { get; set; }
//字段别名:土地退化类型
[TDDBProperty(Column = "TD_TH_LX", Index = 38)]
public string TD_TH_LX { get; set; }
//字段别名:国家级公益林保护等级
[TDDBProperty(Column = "GJGYL_BHDJ", Index = 39)]
public string GJGYL_BHDJ { get; set; }
//字段别名:林地保护等级
[TDDBProperty(Column = "BH_DJ", Index = 40)]
public string BH_DJ { get; set; }
//字段别名:主体功能区
[TDDBProperty(Column = "QYKZ", Index = 41)]
public string QYKZ { get; set; }
//字段别名:事权等级
[TDDBProperty(Column = "SHI_QUAN_D", Index = 42)]
public string SHI_QUAN_D { get; set; }
//字段别名:是否为补充林地
[TDDBProperty(Column = "BCLD", Index = 43)]
public string BCLD { get; set; }
//字段别名:林地功能分区
[TDDBProperty(Column = "LYFQ", Index = 44)]
public string LYFQ { get; set; }
//字段别名:变化原因
[TDDBProperty(Column = "BHYY", Index = 45)]
public string BHYY { get; set; }
//字段别名:变化年度
[TDDBProperty(Column = "BHND", Index = 46)]
public string BHND { get; set; }
//字段别名:林地管理类型
[TDDBProperty(Column = "LDGLLX", Index = 47)]
public string LDGLLX { get; set; }
//字段别名:林木权属
[TDDBProperty(Column = "LMSYQ", Index = 48)]
public string LMSYQ { get; set; }
//字段别名:每公顷株数
[TDDBProperty(Column = "MEI_GQ_ZS", Index = 49)]
public int MEI_GQ_ZS { get; set; }
}
}
