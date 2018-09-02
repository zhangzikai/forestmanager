using System;
using td.db.orm;

namespace td.db.mid.forest
{
[TDDBRecord(Table = "T_ZT_CF_MMJC")]
public class T_ZT_CF_MMJC_Mid
{
[TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
public int ID { get; set; }
//字段别名:村
[TDDBProperty(Column = "CUN", Index = 1)]
public string CUN { get; set; }
//字段别名:林班
[TDDBProperty(Column = "LIN_BAN", Index = 2)]
public string LIN_BAN { get; set; }
//字段别名:调查小班
[TDDBProperty(Column = "DCXB", Index = 3)]
public string DCXB { get; set; }
//字段别名:作业小班
[TDDBProperty(Column = "ZYXB", Index = 4)]
public string ZYXB { get; set; }
//字段别名:标准地号
[TDDBProperty(Column = "BZDH", Index = 5)]
public string BZDH { get; set; }
//字段别名:标准地面积
[TDDBProperty(Column = "BZDMJ", Index = 6)]
public double BZDMJ { get; set; }
//字段别名:检尺树种
[TDDBProperty(Column = "JCSZ", Index = 7)]
public string JCSZ { get; set; }
//字段别名:径阶
[TDDBProperty(Column = "JJ", Index = 8)]
public int JJ { get; set; }
//字段别名:检尺类型
[TDDBProperty(Column = "JCLX", Index = 9)]
public string JCLX { get; set; }
//字段别名:用材株数
[TDDBProperty(Column = "YCZS", Index = 10)]
public int YCZS { get; set; }
//字段别名:半用材株数
[TDDBProperty(Column = "BYCZS", Index = 11)]
public int BYCZS { get; set; }
//字段别名:小材株数
[TDDBProperty(Column = "XCZS", Index = 12)]
public int XCZS { get; set; }
//字段别名:株数合计
[TDDBProperty(Column = "ZSHJ", Index = 13)]
public int ZSHJ { get; set; }
//字段别名:胸径1
[TDDBProperty(Column = "D1", Index = 14)]
public double D1 { get; set; }
//字段别名:树高1
[TDDBProperty(Column = "H1", Index = 15)]
public double H1 { get; set; }
//字段别名:胸径2
[TDDBProperty(Column = "D2", Index = 16)]
public double D2 { get; set; }
//字段别名:树高2
[TDDBProperty(Column = "H2", Index = 17)]
public double H2 { get; set; }
//字段别名:胸径3
[TDDBProperty(Column = "D3", Index = 18)]
public double D3 { get; set; }
//字段别名:树高3
[TDDBProperty(Column = "H3", Index = 19)]
public double H3 { get; set; }
//字段别名:平均高
[TDDBProperty(Column = "PJG", Index = 20)]
public double PJG { get; set; }
//字段别名:平均胸径
[TDDBProperty(Column = "PJZJ", Index = 21)]
public double PJZJ { get; set; }
//字段别名:材积
[TDDBProperty(Column = "CJ", Index = 22)]
public double CJ { get; set; }
//字段别名:用材蓄积
[TDDBProperty(Column = "YCXJ", Index = 23)]
public int YCXJ { get; set; }
//字段别名:半用材蓄积
[TDDBProperty(Column = "BYCXJ", Index = 24)]
public int BYCXJ { get; set; }
//字段别名:小材蓄积
[TDDBProperty(Column = "XCXJ", Index = 25)]
public int XCXJ { get; set; }
//字段别名:规格材出材率
[TDDBProperty(Column = "GGCCCLV", Index = 26)]
public double GGCCCLV { get; set; }
//字段别名:小材出材率
[TDDBProperty(Column = "XCCCLV", Index = 27)]
public double XCCCLV { get; set; }
//字段别名:规格材出材量
[TDDBProperty(Column = "GGCCCL", Index = 28)]
public double GGCCCL { get; set; }
//字段别名:小材出材量
[TDDBProperty(Column = "XCCCL", Index = 29)]
public double XCCCL { get; set; }
//字段别名:断面积
[TDDBProperty(Column = "DMJ", Index = 30)]
public double DMJ { get; set; }
}
}
