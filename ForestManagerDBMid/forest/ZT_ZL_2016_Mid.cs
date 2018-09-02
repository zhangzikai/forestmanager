using System;
using td.db.orm;

namespace td.db.mid.forest
{
    [TDDBRecord(Table = "ZT_ZL_2016")]
    public class ZT_ZL_2016_Mid
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
        //字段别名:变化原因
        [TDDBProperty(Column = "BHYY", Index = 17)]
        public string BHYY { get; set; }
        //字段别名:土壤类型
        [TDDBProperty(Column = "TU_RANG_LX", Index = 18)]
        public string TU_RANG_LX { get; set; }
        //字段别名:优势树种
        [TDDBProperty(Column = "YOU_SHI_SZ", Index = 19)]
        public string YOU_SHI_SZ { get; set; }
        //字段别名:每公顷株数
        [TDDBProperty(Column = "MEI_GQ_ZS", Index = 20)]
        public int MEI_GQ_ZS { get; set; }
        //字段别名:森林类别
        [TDDBProperty(Column = "SEN_LIN_LB", Index = 21)]
        public string SEN_LIN_LB { get; set; }
        //字段别名:工程类别
        [TDDBProperty(Column = "G_CHENG_LB", Index = 22)]
        public string G_CHENG_LB { get; set; }
        //字段别名:林带宽度
        [TDDBProperty(Column = "LD_KD", Index = 23)]
        public double LD_KD { get; set; }
        //字段别名:林带长度
        [TDDBProperty(Column = "LD_CD", Index = 24)]
        public double LD_CD { get; set; }
        //字段别名:更新时间
        [TDDBProperty(Column = "GXSJ", Index = 25)]
        public string GXSJ { get; set; }
        //字段别名:林种
        [TDDBProperty(Column = "LIN_ZHONG", Index = 26)]
        public string LIN_ZHONG { get; set; }
        //字段别名:造林模式
        [TDDBProperty(Column = "ZAO_LIN_MS", Index = 27)]
        public string ZAO_LIN_MS { get; set; }
        //字段别名:造林类别
        [TDDBProperty(Column = "ZAO_LIN_LB", Index = 28)]
        public string ZAO_LIN_LB { get; set; }
        //字段别名:散生木株数
        [TDDBProperty(Column = "SSZZS", Index = 29)]
        public int SSZZS { get; set; }
        //字段别名:资金来源
        [TDDBProperty(Column = "ZJLY", Index = 30)]
        public string ZJLY { get; set; }
        //字段别名:图幅号
        [TDDBProperty(Column = "TFH", Index = 31)]
        public string TFH { get; set; }
        //字段别名:造林户
        [TDDBProperty(Column = "ZLHNAME", Index = 32)]
        public string ZLHNAME { get; set; }
        //字段别名:备注
        [TDDBProperty(Column = "BZ", Index = 33)]
        public string BZ { get; set; }
        //字段别名:检查人员
        [TDDBProperty(Column = "JCRY", Index = 34)]
        public string JCRY { get; set; }
        //字段别名:检查时间
        [TDDBProperty(Column = "JCSJ", Index = 35)]
        public string JCSJ { get; set; }
        //字段别名:造林年度
        [TDDBProperty(Column = "ZLND", Index = 36)]
        public string ZLND { get; set; }
        //字段别名:前期森林类别
        [TDDBProperty(Column = "Q_SEN_LB", Index = 37)]
        public string Q_SEN_LB { get; set; }
        //字段别名:前期林种
        [TDDBProperty(Column = "Q_LIN_ZHONG", Index = 38)]
        public string Q_LIN_ZHONG { get; set; }
        //字段别名:伴生树种
        [TDDBProperty(Column = "BSSZ", Index = 39)]
        public string BSSZ { get; set; }
        //字段别名:抚育方式
        [TDDBProperty(Column = "FYFS", Index = 40)]
        public string FYFS { get; set; }
        //字段别名:中央投资单价
        [TDDBProperty(Column = "ZYTZDJ", Index = 41)]
        public double ZYTZDJ { get; set; }
        //字段别名:中央投资经费
        [TDDBProperty(Column = "ZYTZJF", Index = 42)]
        public double ZYTZJF { get; set; }
        //字段别名:地方投资单价
        [TDDBProperty(Column = "DFTZDJ", Index = 43)]
        public double DFTZDJ { get; set; }
        //字段别名:地方投资经费
        [TDDBProperty(Column = "DFTZJF", Index = 44)]
        public double DFTZJF { get; set; }
        //字段别名:计划年度
        [TDDBProperty(Column = "JHND", Index = 45)]
        public int JHND { get; set; }
        //字段别名:核实面积
        [TDDBProperty(Column = "HSMJ", Index = 46)]
        public double HSMJ { get; set; }
        //字段别名:合格面积
        [TDDBProperty(Column = "HGMJ", Index = 47)]
        public double HGMJ { get; set; }
        //字段别名:不合格面积
        [TDDBProperty(Column = "BHGMJ", Index = 48)]
        public double BHGMJ { get; set; }
        //字段别名:损失面积
        [TDDBProperty(Column = "SSMJ", Index = 49)]
        public double SSMJ { get; set; }
        //字段别名:不核实原因
        [TDDBProperty(Column = "BHSYY", Index = 50)]
        public string BHSYY { get; set; }
        //字段别名:不合格原因
        [TDDBProperty(Column = "BHGYY", Index = 51)]
        public string BHGYY { get; set; }
        //字段别名:损失原因
        [TDDBProperty(Column = "SSYY", Index = 52)]
        public string SSYY { get; set; }
    }
}
