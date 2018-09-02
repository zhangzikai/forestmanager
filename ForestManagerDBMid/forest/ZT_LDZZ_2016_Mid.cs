using System;
using td.db.orm;

namespace td.db.mid.forest
{
    [TDDBRecord(Table = "ZT_LDZZ_2016")]
    public class ZT_LDZZ_2016_Mid
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
        //字段别名:占用征收单位
        [TDDBProperty(Column = "ZYBM", Index = 18)]
        public string ZYBM { get; set; }
        //字段别名:是否实施
        [TDDBProperty(Column = "XFSS", Index = 19)]
        public string XFSS { get; set; }
        //字段别名:更新时间
        [TDDBProperty(Column = "GXSJ", Index = 20)]
        public string GXSJ { get; set; }
        //字段别名:项目编号
        [TDDBProperty(Column = "XMBH", Index = 21)]
        public string XMBH { get; set; }
        //字段别名:项目名称
        [TDDBProperty(Column = "XMMC", Index = 22)]
        public string XMMC { get; set; }
        //字段别名:林地类型
        [TDDBProperty(Column = "LDLX", Index = 23)]
        public string LDLX { get; set; }
        //字段别名:林地用途
        [TDDBProperty(Column = "LDYT", Index = 24)]
        public string LDYT { get; set; }
        //字段别名:项目类型
        [TDDBProperty(Column = "XMLX", Index = 25)]
        public string XMLX { get; set; }
        //字段别名:用地种类
        [TDDBProperty(Column = "YDZL", Index = 26)]
        public string YDZL { get; set; }
        //字段别名:是否城市及城市规划区林地
        [TDDBProperty(Column = "YDFW", Index = 27)]
        public string YDFW { get; set; }
        //字段别名:森林类别
        [TDDBProperty(Column = "SEN_LIN_LB", Index = 28)]
        public string SEN_LIN_LB { get; set; }
        //字段别名:事权等级
        [TDDBProperty(Column = "SHI_QUAN_D", Index = 29)]
        public string SHI_QUAN_D { get; set; }
        //字段别名:国家级公益林保护等级
        [TDDBProperty(Column = "GJGYL_BHDJ", Index = 30)]
        public string GJGYL_BHDJ { get; set; }
        //字段别名:保护等级
        [TDDBProperty(Column = "BH_DJ", Index = 31)]
        public string BH_DJ { get; set; }
        //字段别名:林种
        [TDDBProperty(Column = "LIN_ZHONG", Index = 32)]
        public string LIN_ZHONG { get; set; }
        //字段别名:郁闭度
        [TDDBProperty(Column = "YU_BI_DU", Index = 33)]
        public double YU_BI_DU { get; set; }
        //字段别名:经济林产期
        [TDDBProperty(Column = "JJLCQ", Index = 34)]
        public string JJLCQ { get; set; }
        //字段别名:线状物种类
        [TDDBProperty(Column = "XZWZL", Index = 35)]
        public string XZWZL { get; set; }
        //字段别名:线状物长度
        [TDDBProperty(Column = "XZWCD", Index = 36)]
        public double XZWCD { get; set; }
        //字段别名:线状物宽度
        [TDDBProperty(Column = "XZWKD", Index = 37)]
        public double XZWKD { get; set; }
        //字段别名:优势树种
        [TDDBProperty(Column = "YOU_SHI_SZ", Index = 38)]
        public string YOU_SHI_SZ { get; set; }
        //字段别名:起源
        [TDDBProperty(Column = "QI_YUAN", Index = 39)]
        public string QI_YUAN { get; set; }
        //字段别名:平均年龄
        [TDDBProperty(Column = "PINGJUN_NL", Index = 40)]
        public int PINGJUN_NL { get; set; }
        //字段别名:平均胸径
        [TDDBProperty(Column = "PINGJUN_XJ", Index = 41)]
        public double PINGJUN_XJ { get; set; }
        //字段别名:平均树高
        [TDDBProperty(Column = "PINGJUN_SG", Index = 42)]
        public double PINGJUN_SG { get; set; }
        //字段别名:平均断面
        [TDDBProperty(Column = "PINGJUN_DM", Index = 43)]
        public double PINGJUN_DM { get; set; }
        //字段别名:龄组
        [TDDBProperty(Column = "LING_ZU", Index = 44)]
        public string LING_ZU { get; set; }
        //字段别名:线状物面积
        [TDDBProperty(Column = "XZWMJ", Index = 45)]
        public double XZWMJ { get; set; }
        //字段别名:森林蓄积
        [TDDBProperty(Column = "SLXJ", Index = 46)]
        public int SLXJ { get; set; }
        //字段别名:小班ID
        [TDDBProperty(Column = "XBID", Index = 47)]
        public string XBID { get; set; }
        //字段别名:是否退耕地
        [TDDBProperty(Column = "SFTGD", Index = 48)]
        public string SFTGD { get; set; }
        //字段别名:备注
        [TDDBProperty(Column = "BZ", Index = 49)]
        public string BZ { get; set; }
        //字段别名:林地补偿费单价
        [TDDBProperty(Column = "LDBCDJ", Index = 50)]
        public double LDBCDJ { get; set; }
        //字段别名:林地补偿费
        [TDDBProperty(Column = "LDBCF", Index = 51)]
        public double LDBCF { get; set; }
        //字段别名:林地安置费单价
        [TDDBProperty(Column = "LDAZFDJ", Index = 52)]
        public double LDAZFDJ { get; set; }
        //字段别名:林地安置费
        [TDDBProperty(Column = "LDAZF", Index = 53)]
        public double LDAZF { get; set; }
        //字段别名:林木补偿费单价
        [TDDBProperty(Column = "LMBCDJ", Index = 54)]
        public double LMBCDJ { get; set; }
        //字段别名:林木补偿费
        [TDDBProperty(Column = "LMBCF", Index = 55)]
        public double LMBCF { get; set; }
        //字段别名:补偿费合计
        [TDDBProperty(Column = "BCFHJ", Index = 56)]
        public double BCFHJ { get; set; }
        //字段别名:植被恢复费单价
        [TDDBProperty(Column = "ZBHFDJ", Index = 57)]
        public double ZBHFDJ { get; set; }
        //字段别名:植被恢复费
        [TDDBProperty(Column = "ZBHFF", Index = 58)]
        public double ZBHFF { get; set; }
        //字段别名:总费用合计
        [TDDBProperty(Column = "ZFYHJ", Index = 59)]
        public double ZFYHJ { get; set; }
        //字段别名:审核时间
        [TDDBProperty(Column = "SHSJ", Index = 60)]
        public string SHSJ { get; set; }
        //字段别名:前期森林类别
        [TDDBProperty(Column = "Q_SEN_LB", Index = 61)]
        public string Q_SEN_LB { get; set; }
        //字段别名:前期林种
        [TDDBProperty(Column = "Q_LIN_ZHONG", Index = 62)]
        public string Q_LIN_ZHONG { get; set; }
        //字段别名:主体功能区
        [TDDBProperty(Column = "QYKZ", Index = 63)]
        public string QYKZ { get; set; }
        //字段别名:林地功能分区
        [TDDBProperty(Column = "LYFQ", Index = 64)]
        public string LYFQ { get; set; }
        //字段别名:林地质量等级
        [TDDBProperty(Column = "ZL_DJ", Index = 65)]
        public string ZL_DJ { get; set; }
        //字段别名:审批面积
        [TDDBProperty(Column = "SPMJ", Index = 66)]
        public double SPMJ { get; set; }
        //字段别名:每公顷株数
        [TDDBProperty(Column = "MEI_GQ_ZS", Index = 67)]
        public int MEI_GQ_ZS { get; set; }
        //字段别名:伴生树种
        [TDDBProperty(Column = "BSSZ", Index = 68)]
        public string BSSZ { get; set; }
        //字段别名:审批级别
        [TDDBProperty(Column = "SPJB", Index = 69)]
        public string SPJB { get; set; }
        //字段别名:直接服务对象
        [TDDBProperty(Column = "ZJFWDX", Index = 70)]
        public string ZJFWDX { get; set; }
        //字段别名:批准文号
        [TDDBProperty(Column = "PZWH", Index = 71)]
        public string PZWH { get; set; }
        //字段别名:记录时间
        [TDDBProperty(Column = "JLSJ", Index = 72)]
        public string JLSJ { get; set; }
    }
}
