using System;
using td.db.orm;

namespace td.db.mid.forest
{
    [TDDBRecord(Table = "ZT_CF")]
    public class ZT_CF_Mid
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
        //字段别名:图斑(小班)
        [TDDBProperty(Column = "XIAO_BAN", Index = 7)]
        public string XIAO_BAN { get; set; }
        //字段别名:设计编号
        [TDDBProperty(Column = "SJBH", Index = 8)]
        public string SJBH { get; set; }
        //字段别名:调查人员
        [TDDBProperty(Column = "DCRY", Index = 9)]
        public string DCRY { get; set; }
        //字段别名:设计人员
        [TDDBProperty(Column = "SJRY", Index = 10)]
        public string SJRY { get; set; }
        //字段别名:小地名
        [TDDBProperty(Column = "XIAODM", Index = 11)]
        public string XIAODM { get; set; }
        //字段别名:东至
        [TDDBProperty(Column = "EAST", Index = 12)]
        public string EAST { get; set; }
        //字段别名:西至
        [TDDBProperty(Column = "WEST", Index = 13)]
        public string WEST { get; set; }
        //字段别名:南至
        [TDDBProperty(Column = "SOUTH", Index = 14)]
        public string SOUTH { get; set; }
        //字段别名:北至
        [TDDBProperty(Column = "NORTH", Index = 15)]
        public string NORTH { get; set; }
        //字段别名:林木所有者姓名
        [TDDBProperty(Column = "LMSYZXM", Index = 16)]
        public string LMSYZXM { get; set; }
        //字段别名:单位
        [TDDBProperty(Column = "DW", Index = 17)]
        public string DW { get; set; }
        //字段别名:面积
        [TDDBProperty(Column = "MIAN_JI", Index = 18)]
        public double MIAN_JI { get; set; }
        //字段别名:前期地类
        [TDDBProperty(Column = "Q_DI_LEI", Index = 19)]
        public string Q_DI_LEI { get; set; }
        //字段别名:地类
        [TDDBProperty(Column = "DI_LEI", Index = 20)]
        public string DI_LEI { get; set; }
        //字段别名:前期土地权属
        [TDDBProperty(Column = "Q_LD_QS", Index = 21)]
        public string Q_LD_QS { get; set; }
        //字段别名:土地权属
        [TDDBProperty(Column = "LD_QS", Index = 22)]
        public string LD_QS { get; set; }
        //字段别名:土地使用权
        [TDDBProperty(Column = "TDJYQ", Index = 23)]
        public string TDJYQ { get; set; }
        //字段别名:林木所有权
        [TDDBProperty(Column = "LMSYQ", Index = 24)]
        public string LMSYQ { get; set; }
        //字段别名:林木使用权
        [TDDBProperty(Column = "LMJYQ", Index = 25)]
        public string LMJYQ { get; set; }
        //字段别名:坡向
        [TDDBProperty(Column = "PO_XIANG", Index = 26)]
        public string PO_XIANG { get; set; }
        //字段别名:坡度
        [TDDBProperty(Column = "PO_DU", Index = 27)]
        public string PO_DU { get; set; }
        //字段别名:坡位
        [TDDBProperty(Column = "PO_WEI", Index = 28)]
        public string PO_WEI { get; set; }
        //字段别名:海拔
        [TDDBProperty(Column = "HBG", Index = 29)]
        public int HBG { get; set; }
        //字段别名:母岩
        [TDDBProperty(Column = "CTMY", Index = 30)]
        public string CTMY { get; set; }
        //字段别名:土壤
        [TDDBProperty(Column = "TU_RANG_LX", Index = 31)]
        public string TU_RANG_LX { get; set; }
        //字段别名:土层厚度
        [TDDBProperty(Column = "TU_CENG_HD", Index = 32)]
        public int TU_CENG_HD { get; set; }
        //字段别名:前期森林类别
        [TDDBProperty(Column = "Q_SEN_LB", Index = 33)]
        public string Q_SEN_LB { get; set; }
        //字段别名:森林类别
        [TDDBProperty(Column = "SEN_LIN_LB", Index = 34)]
        public string SEN_LIN_LB { get; set; }
        //字段别名:前期林种
        [TDDBProperty(Column = "Q_LIN_ZHONG", Index = 35)]
        public string Q_LIN_ZHONG { get; set; }
        //字段别名:林种
        [TDDBProperty(Column = "LIN_ZHONG", Index = 36)]
        public string LIN_ZHONG { get; set; }
        //字段别名:公益林保护等级
        [TDDBProperty(Column = "GJGYL_BHDJ", Index = 37)]
        public string GJGYL_BHDJ { get; set; }
        //字段别名:林龄
        [TDDBProperty(Column = "PINGJUN_NL", Index = 38)]
        public int PINGJUN_NL { get; set; }
        //字段别名:龄组
        [TDDBProperty(Column = "LING_ZU", Index = 39)]
        public string LING_ZU { get; set; }
        //字段别名:郁闭度
        [TDDBProperty(Column = "YU_BI_DU", Index = 40)]
        public double YU_BI_DU { get; set; }
        //字段别名:起源
        [TDDBProperty(Column = "QI_YUAN", Index = 41)]
        public string QI_YUAN { get; set; }
        //字段别名:树种
        [TDDBProperty(Column = "YOU_SHI_SZ", Index = 42)]
        public string YOU_SHI_SZ { get; set; }
        //字段别名:平均胸径
        [TDDBProperty(Column = "PINGJUN_XJ", Index = 43)]
        public double PINGJUN_XJ { get; set; }
        //字段别名:平均树高
        [TDDBProperty(Column = "PINGJUN_SG", Index = 44)]
        public double PINGJUN_SG { get; set; }
        //字段别名:每公顷蓄积
        [TDDBProperty(Column = "HUO_LMGQXJ", Index = 45)]
        public int HUO_LMGQXJ { get; set; }
        //字段别名:每公顷株数
        [TDDBProperty(Column = "MEI_GQ_ZS", Index = 46)]
        public int MEI_GQ_ZS { get; set; }
        //字段别名:伐区蓄积
        [TDDBProperty(Column = "ZXJ", Index = 47)]
        public int ZXJ { get; set; }
        //字段别名:伐区株数
        [TDDBProperty(Column = "FQZS", Index = 48)]
        public int FQZS { get; set; }
        //字段别名:采伐类型
        [TDDBProperty(Column = "CFLX", Index = 49)]
        public string CFLX { get; set; }
        //字段别名:采伐方式
        [TDDBProperty(Column = "CFFS", Index = 50)]
        public string CFFS { get; set; }
        //字段别名:采伐强度
        [TDDBProperty(Column = "CFQD", Index = 51)]
        public int CFQD { get; set; }
        //字段别名:采伐面积
        [TDDBProperty(Column = "CFMJ", Index = 52)]
        public double CFMJ { get; set; }
        //字段别名:采伐蓄积
        [TDDBProperty(Column = "CFXJ", Index = 53)]
        public int CFXJ { get; set; }
        //字段别名:规格材出材量
        [TDDBProperty(Column = "GGCCCL", Index = 54)]
        public double GGCCCL { get; set; }
        //字段别名:非规格材出材量
        [TDDBProperty(Column = "FGGCCCL", Index = 55)]
        public double FGGCCCL { get; set; }
        //字段别名:出材率
        [TDDBProperty(Column = "CCLV", Index = 56)]
        public double CCLV { get; set; }
        //字段别名:伐后保留木公顷株数
        [TDDBProperty(Column = "BLMGQZS", Index = 57)]
        public int BLMGQZS { get; set; }
        //字段别名:伐后保留木郁闭度
        [TDDBProperty(Column = "BLMYBD", Index = 58)]
        public double BLMYBD { get; set; }
        //字段别名:采伐时间
        [TDDBProperty(Column = "CFSJ", Index = 59)]
        public string CFSJ { get; set; }
        //字段别名:伐木方法
        [TDDBProperty(Column = "FMFF", Index = 60)]
        public string FMFF { get; set; }
        //字段别名:集材方式
        [TDDBProperty(Column = "JCFS", Index = 61)]
        public string JCFS { get; set; }
        //字段别名:更新时间
        [TDDBProperty(Column = "GENGXINSJ", Index = 62)]
        public string GENGXINSJ { get; set; }
        //字段别名:更新面积
        [TDDBProperty(Column = "GXMJ", Index = 63)]
        public double GXMJ { get; set; }
        //字段别名:更新树种
        [TDDBProperty(Column = "GXSZ", Index = 64)]
        public string GXSZ { get; set; }
        //字段别名:更新方式
        [TDDBProperty(Column = "GXFS", Index = 65)]
        public string GXFS { get; set; }
        //字段别名:整地方式
        [TDDBProperty(Column = "ZDFS", Index = 66)]
        public string ZDFS { get; set; }
        //字段别名:整地规格
        [TDDBProperty(Column = "ZDGG", Index = 67)]
        public string ZDGG { get; set; }
        //字段别名:造林密度
        [TDDBProperty(Column = "ZLMD", Index = 68)]
        public int ZLMD { get; set; }
        //字段别名:株行距
        [TDDBProperty(Column = "ZHUHJ", Index = 69)]
        public string ZHUHJ { get; set; }
        //字段别名:苗木规格
        [TDDBProperty(Column = "MIAOMUGG", Index = 70)]
        public string MIAOMUGG { get; set; }
        //字段别名:用苗量
        [TDDBProperty(Column = "YML", Index = 71)]
        public int YML { get; set; }
        //字段别名:抚育措施
        [TDDBProperty(Column = "FYCS", Index = 72)]
        public string FYCS { get; set; }
        //字段别名:更新责任人
        [TDDBProperty(Column = "GXZRR", Index = 73)]
        public string GXZRR { get; set; }
        //字段别名:其他说明
        [TDDBProperty(Column = "QTSM", Index = 74)]
        public string QTSM { get; set; }
        //字段别名:采伐次数
        [TDDBProperty(Column = "CFCS", Index = 75)]
        public int CFCS { get; set; }
        //字段别名:平均冠幅
        [TDDBProperty(Column = "PJGF", Index = 76)]
        public double PJGF { get; set; }
        //字段别名:散生木株数
        [TDDBProperty(Column = "SSZZS", Index = 77)]
        public int SSZZS { get; set; }
        //字段别名:散生蓄积
        [TDDBProperty(Column = "SSXJ", Index = 78)]
        public int SSXJ { get; set; }
        //字段别名:更新等级
        [TDDBProperty(Column = "GXDJ", Index = 79)]
        public string GXDJ { get; set; }
        //字段别名:变化原因
        [TDDBProperty(Column = "BHYY", Index = 80)]
        public string BHYY { get; set; }
        //字段别名:变更时间
        [TDDBProperty(Column = "GXSJ", Index = 81)]
        public string GXSJ { get; set; }
        //字段别名:是否采伐
        [TDDBProperty(Column = "SFCF", Index = 82)]
        public string SFCF { get; set; }
        //字段别名:是否复制
        [TDDBProperty(Column = "IS_COPIED", Index = 83)]
        public string IS_COPIED { get; set; }
        //字段别名:采伐株数
        [TDDBProperty(Column = "CFZS", Index = 84)]
        public int CFZS { get; set; }
        //字段别名:保留木公顷蓄积
        [TDDBProperty(Column = "BLMGQXJ", Index = 85)]
        public int BLMGQXJ { get; set; }
        //字段别名:细斑
        [TDDBProperty(Column = "XI_BAN", Index = 86)]
        public string XI_BAN { get; set; }
        //字段别名:作业设计编号
        [TDDBProperty(Column = "TASK_ID", Index = 87)]
        public string TASK_ID { get; set; }
    }
}
