using System;
using td.db.orm;

namespace td.db.mid.forest
{
    [TDDBRecord(Table = "FOR_XIAOBAN_NOW")]
    public class FOR_XIAOBAN_Mid
    {

        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:省（区、市）
        [TDDBProperty(Column = "SHENG", Index = 1)]
        public string SHENG { get; set; }
        //字段别名:市
        [TDDBProperty(Column = "SHI", Index = 2)]
        public string SHI { get; set; }
        //字段别名:县（市、旗）
        [TDDBProperty(Column = "XIAN", Index = 3)]
        public string XIAN { get; set; }
        //字段别名:乡
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
        //字段别名:图斑（小班）
        [TDDBProperty(Column = "XIAO_BAN", Index = 9)]
        public string XIAO_BAN { get; set; }
        //字段别名:细斑
        [TDDBProperty(Column = "XI_BAN", Index = 10)]
        public string XI_BAN { get; set; }
        //字段别名:前期土地权属
        [TDDBProperty(Column = "Q_LD_QS", Index = 11)]
        public string Q_LD_QS { get; set; }
        //字段别名:土地权属
        [TDDBProperty(Column = "LD_QS", Index = 12)]
        public string LD_QS { get; set; }
        //字段别名:土地使用权
        [TDDBProperty(Column = "TDJYQ", Index = 13)]
        public string TDJYQ { get; set; }
        //字段别名:林木所有权
        [TDDBProperty(Column = "LMSYQ", Index = 14)]
        public string LMSYQ { get; set; }
        //字段别名:林木使用权
        [TDDBProperty(Column = "LMJYQ", Index = 15)]
        public string LMJYQ { get; set; }
        //字段别名:面积
        [TDDBProperty(Column = "MIAN_JI", Index = 16)]
        public double MIAN_JI { get; set; }
        //字段别名:前期地类
        [TDDBProperty(Column = "Q_DI_LEI", Index = 17)]
        public string Q_DI_LEI { get; set; }
        //字段别名:地类
        [TDDBProperty(Column = "DI_LEI", Index = 18)]
        public string DI_LEI { get; set; }
        //字段别名:前期森林类别
        [TDDBProperty(Column = "Q_SEN_LB", Index = 19)]
        public string Q_SEN_LB { get; set; }
        //字段别名:森林类别
        [TDDBProperty(Column = "SEN_LIN_LB", Index = 20)]
        public string SEN_LIN_LB { get; set; }
        //字段别名:工程类别
        [TDDBProperty(Column = "G_CHENG_LB", Index = 21)]
        public string G_CHENG_LB { get; set; }
        //字段别名:事权等级
        [TDDBProperty(Column = "SHI_QUAN_D", Index = 22)]
        public string SHI_QUAN_D { get; set; }
        //字段别名:国家级公益林保护等级
        [TDDBProperty(Column = "GJGYL_BHDJ", Index = 23)]
        public string GJGYL_BHDJ { get; set; }
        //字段别名:林地质量等级
        [TDDBProperty(Column = "ZL_DJ", Index = 24)]
        public string ZL_DJ { get; set; }
        //字段别名:林地保护等级
        [TDDBProperty(Column = "BH_DJ", Index = 25)]
        public string BH_DJ { get; set; }
        //字段别名:林地功能分区
        [TDDBProperty(Column = "LYFQ", Index = 26)]
        public string LYFQ { get; set; }
        //字段别名:主体功能区
        [TDDBProperty(Column = "QYKZ", Index = 27)]
        public string QYKZ { get; set; }
        //字段别名:是否为补充林地
        [TDDBProperty(Column = "BCLD", Index = 28)]
        public string BCLD { get; set; }
        //字段别名:变化原因
        [TDDBProperty(Column = "BHYY", Index = 29)]
        public string BHYY { get; set; }
        //字段别名:变化年度
        [TDDBProperty(Column = "BHND", Index = 30)]
        public string BHND { get; set; }
        //字段别名:地貌
        [TDDBProperty(Column = "DI_MAO", Index = 31)]
        public string DI_MAO { get; set; }
        //字段别名:海拔高
        [TDDBProperty(Column = "HBG", Index = 32)]
        public int HBG { get; set; }
        //字段别名:坡向
        [TDDBProperty(Column = "PO_XIANG", Index = 33)]
        public string PO_XIANG { get; set; }
        //字段别名:坡位
        [TDDBProperty(Column = "PO_WEI", Index = 34)]
        public string PO_WEI { get; set; }
        //字段别名:坡度
        [TDDBProperty(Column = "PO_DU", Index = 35)]
        public string PO_DU { get; set; }
        //字段别名:土壤类型
        [TDDBProperty(Column = "TU_RANG_LX", Index = 36)]
        public string TU_RANG_LX { get; set; }
        //字段别名:土层厚度
        [TDDBProperty(Column = "TU_CENG_HD", Index = 37)]
        public int TU_CENG_HD { get; set; }
        //字段别名:枯枝落叶层厚度
        [TDDBProperty(Column = "KZLYH", Index = 38)]
        public int KZLYH { get; set; }
        //字段别名:腐殖质层厚度
        [TDDBProperty(Column = "FZCH", Index = 39)]
        public int FZCH { get; set; }
        //字段别名:石砾含量
        [TDDBProperty(Column = "SLHL", Index = 40)]
        public int SLHL { get; set; }
        //字段别名:成土母岩
        [TDDBProperty(Column = "CTMY", Index = 41)]
        public string CTMY { get; set; }
        //字段别名:侵蚀类型
        [TDDBProperty(Column = "QSLX", Index = 42)]
        public string QSLX { get; set; }
        //字段别名:侵蚀程度
        [TDDBProperty(Column = "QSCD", Index = 43)]
        public string QSCD { get; set; }
        //字段别名:土地退化类型
        [TDDBProperty(Column = "TD_TH_LX", Index = 44)]
        public string TD_TH_LX { get; set; }
        //字段别名:灌木层优势种
        [TDDBProperty(Column = "GMYSZ", Index = 45)]
        public string GMYSZ { get; set; }
        //字段别名:灌木层平均高
        [TDDBProperty(Column = "GMPJGD", Index = 46)]
        public double GMPJGD { get; set; }
        //字段别名:灌木层总盖度
        [TDDBProperty(Column = "GMZGD", Index = 47)]
        public double GMZGD { get; set; }
        //字段别名:草本层优势种
        [TDDBProperty(Column = "CBYSZ", Index = 48)]
        public string CBYSZ { get; set; }
        //字段别名:草本层平均高
        [TDDBProperty(Column = "CBPJGD", Index = 49)]
        public double CBPJGD { get; set; }
        //字段别名:草本层总盖度
        [TDDBProperty(Column = "CBZGD", Index = 50)]
        public double CBZGD { get; set; }
        //字段别名:下木优势树种
        [TDDBProperty(Column = "GXYSSZ", Index = 51)]
        public string GXYSSZ { get; set; }
        //字段别名:下木平均年龄
        [TDDBProperty(Column = "GXPJNL", Index = 52)]
        public int GXPJNL { get; set; }
        //字段别名:下木平均高度
        [TDDBProperty(Column = "GXPJGD", Index = 53)]
        public double GXPJGD { get; set; }
        //字段别名:下木公顷株数
        [TDDBProperty(Column = "GXGQZS", Index = 54)]
        public int GXGQZS { get; set; }
        //字段别名:下木分布情况
        [TDDBProperty(Column = "GXFBQK", Index = 55)]
        public string GXFBQK { get; set; }
        //字段别名:下木生长情况
        [TDDBProperty(Column = "GXSZQK", Index = 56)]
        public string GXSZQK { get; set; }
        //字段别名:灾害类型
        [TDDBProperty(Column = "DISPE", Index = 57)]
        public string DISPE { get; set; }
        //字段别名:灾害等级
        [TDDBProperty(Column = "DISASTER_C", Index = 58)]
        public string DISASTER_C { get; set; }
        //字段别名:健康状况
        [TDDBProperty(Column = "JKZK", Index = 59)]
        public string JKZK { get; set; }
        //字段别名:石漠化类型
        [TDDBProperty(Column = "SMHLX", Index = 60)]
        public string SMHLX { get; set; }
        //字段别名:石漠化程度
        [TDDBProperty(Column = "SMHCD", Index = 61)]
        public string SMHCD { get; set; }
        //字段别名:石漠化成因
        [TDDBProperty(Column = "SMHCY", Index = 62)]
        public string SMHCY { get; set; }
        //字段别名:沙化类型
        [TDDBProperty(Column = "SHLX", Index = 63)]
        public string SHLX { get; set; }
        //字段别名:沙化程度
        [TDDBProperty(Column = "SHCD", Index = 64)]
        public string SHCD { get; set; }
        //字段别名:湿地类型
        [TDDBProperty(Column = "SDLX", Index = 65)]
        public string SDLX { get; set; }
        //字段别名:前期林种
        [TDDBProperty(Column = "Q_LIN_ZHONG", Index = 66)]
        public string Q_LIN_ZHONG { get; set; }
        //字段别名:林种
        [TDDBProperty(Column = "LIN_ZHONG", Index = 67)]
        public string LIN_ZHONG { get; set; }
        //字段别名:经营类型
        [TDDBProperty(Column = "JYLX", Index = 68)]
        public string JYLX { get; set; }
        //字段别名:群落结构
        [TDDBProperty(Column = "QLJG", Index = 69)]
        public string QLJG { get; set; }
        //字段别名:自然度
        [TDDBProperty(Column = "ZRD", Index = 70)]
        public string ZRD { get; set; }
        //字段别名:经营措施类型
        [TDDBProperty(Column = "JYCSLX", Index = 71)]
        public string JYCSLX { get; set; }
        //字段别名:郁闭度/覆盖度
        [TDDBProperty(Column = "YU_BI_DU", Index = 72)]
        public double YU_BI_DU { get; set; }
        //字段别名:优势木高
        [TDDBProperty(Column = "YSMG", Index = 73)]
        public double YSMG { get; set; }
        //字段别名:交通区位
        [TDDBProperty(Column = "KE_JI_DU", Index = 74)]
        public string KE_JI_DU { get; set; }
        //字段别名:经济林产期
        [TDDBProperty(Column = "JJLCQ", Index = 75)]
        public string JJLCQ { get; set; }
        //字段别名:散生类型
        [TDDBProperty(Column = "SSLX", Index = 76)]
        public string SSLX { get; set; }
        //字段别名:散生主要树种
        [TDDBProperty(Column = "SSZYSZ", Index = 77)]
        public string SSZYSZ { get; set; }
        //字段别名:散生总株数
        [TDDBProperty(Column = "SSZZS", Index = 78)]
        public int SSZZS { get; set; }
        //字段别名:散生平均胸径
        [TDDBProperty(Column = "SSPJXJ", Index = 79)]
        public double SSPJXJ { get; set; }
        //字段别名:散生平均高度
        [TDDBProperty(Column = "SSPJGD", Index = 80)]
        public double SSPJGD { get; set; }
        //字段别名:线状物种类
        [TDDBProperty(Column = "XZWZL", Index = 81)]
        public string XZWZL { get; set; }
        //字段别名:线状物长度
        [TDDBProperty(Column = "XZWCD", Index = 82)]
        public double XZWCD { get; set; }
        //字段别名:线状物宽度
        [TDDBProperty(Column = "XZWKD", Index = 83)]
        public double XZWKD { get; set; }
        //字段别名:林带宽度
        [TDDBProperty(Column = "LD_KD", Index = 84)]
        public double LD_KD { get; set; }
        //字段别名:林带长度
        [TDDBProperty(Column = "LD_CD", Index = 85)]
        public double LD_CD { get; set; }
        //字段别名:优势树种
        [TDDBProperty(Column = "YOU_SHI_SZ", Index = 86)]
        public string YOU_SHI_SZ { get; set; }
        //字段别名:起源
        [TDDBProperty(Column = "QI_YUAN", Index = 87)]
        public string QI_YUAN { get; set; }
        //字段别名:出材率等级
        [TDDBProperty(Column = "CCLDJ", Index = 88)]
        public string CCLDJ { get; set; }
        //字段别名:大径木蓄积比等级
        [TDDBProperty(Column = "XJBDJ", Index = 89)]
        public string XJBDJ { get; set; }
        //字段别名:平均年龄
        [TDDBProperty(Column = "PINGJUN_NL", Index = 90)]
        public int PINGJUN_NL { get; set; }
        //字段别名:平均胸径
        [TDDBProperty(Column = "PINGJUN_XJ", Index = 91)]
        public double PINGJUN_XJ { get; set; }
        //字段别名:平均树高
        [TDDBProperty(Column = "PINGJUN_SG", Index = 92)]
        public double PINGJUN_SG { get; set; }
        //字段别名:平均断面积
        [TDDBProperty(Column = "PINGJUN_DM", Index = 93)]
        public double PINGJUN_DM { get; set; }
        //字段别名:每公顷株数
        [TDDBProperty(Column = "MEI_GQ_ZS", Index = 94)]
        public int MEI_GQ_ZS { get; set; }
        //字段别名:伴生树种名称
        [TDDBProperty(Column = "BSSZ", Index = 95)]
        public string BSSZ { get; set; }
        //字段别名:伴生树种起源
        [TDDBProperty(Column = "BSSZQY", Index = 96)]
        public string BSSZQY { get; set; }
        //字段别名:伴生树种年龄
        [TDDBProperty(Column = "BSSZNL", Index = 97)]
        public int BSSZNL { get; set; }
        //字段别名:伴生树种平均高
        [TDDBProperty(Column = "BSSZSG", Index = 98)]
        public double BSSZSG { get; set; }
        //字段别名:伴生树种平均胸径
        [TDDBProperty(Column = "BSSZPJXJ", Index = 99)]
        public double BSSZPJXJ { get; set; }
        //字段别名:伴生树种每公顷断面积
        [TDDBProperty(Column = "BSSZGQDM", Index = 100)]
        public double BSSZGQDM { get; set; }
        //字段别名:伴生树种每公顷株数
        [TDDBProperty(Column = "BSSZGQZS", Index = 101)]
        public int BSSZGQZS { get; set; }
        //字段别名:林业区划分区编号
        [TDDBProperty(Column = "QHFQBH", Index = 102)]
        public string QHFQBH { get; set; }
        //字段别名:林地所有单位
        [TDDBProperty(Column = "LDSYDW", Index = 103)]
        public double LDSYDW { get; set; }
        //字段别名:法人造林单位
        [TDDBProperty(Column = "FRZLDW", Index = 104)]
        public double FRZLDW { get; set; }
        //字段别名:有效面积
        [TDDBProperty(Column = "YXMJ", Index = 105)]
        public double YXMJ { get; set; }
        //字段别名:线状物面积
        [TDDBProperty(Column = "XZWMJ", Index = 106)]
        public double XZWMJ { get; set; }
        //字段别名:总蓄积
        [TDDBProperty(Column = "ZXJ", Index = 107)]
        public int ZXJ { get; set; }
        //字段别名:森林蓄积
        [TDDBProperty(Column = "SLXJ", Index = 108)]
        public int SLXJ { get; set; }
        //字段别名:优势树种蓄积
        [TDDBProperty(Column = "YSSZXJ", Index = 109)]
        public int YSSZXJ { get; set; }
        //字段别名:伴生树种蓄积
        [TDDBProperty(Column = "BSSZXJ", Index = 110)]
        public int BSSZXJ { get; set; }
        //字段别名:散生四旁蓄积
        [TDDBProperty(Column = "SSXJ", Index = 111)]
        public int SSXJ { get; set; }
        //字段别名:公顷蓄积(活立木)
        [TDDBProperty(Column = "HUO_LMGQXJ", Index = 112)]
        public int HUO_LMGQXJ { get; set; }
        //字段别名:主伐年龄
        [TDDBProperty(Column = "ZFNL", Index = 113)]
        public int ZFNL { get; set; }
        //字段别名:造林年度
        [TDDBProperty(Column = "ZLND", Index = 114)]
        public int ZLND { get; set; }
        //字段别名:龄组
        [TDDBProperty(Column = "LING_ZU", Index = 115)]
        public string LING_ZU { get; set; }
        //字段别名:龄级
        [TDDBProperty(Column = "LJ", Index = 116)]
        public string LJ { get; set; }
        //字段别名:备用因子1
        [TDDBProperty(Column = "BAK1", Index = 117)]
        public double BAK1 { get; set; }
        //字段别名:备用因子2
        [TDDBProperty(Column = "BAK2", Index = 118)]
        public double BAK2 { get; set; }
        //字段别名:细斑唯一编号
        [TDDBProperty(Column = "XBID", Index = 119)]
        public string XBID { get; set; }
        //字段别名:说明
        [TDDBProperty(Column = "Remarks", Index = 120)]
        public string Remarks { get; set; }
        //字段别名:更新时间
        [TDDBProperty(Column = "GXSJ", Index = 121)]
        public string GXSJ { get; set; }
        //字段别名:前期事权等级
        [TDDBProperty(Column = "Q_SQ_D", Index = 122)]
        public string Q_SQ_D { get; set; }
        //字段别名:前期工程类别
        [TDDBProperty(Column = "Q_GC_LB", Index = 123)]
        public string Q_GC_LB { get; set; }
        //字段别名:生态区位
        [TDDBProperty(Column = "STQW", Index = 124)]
        public string STQW { get; set; }
        //字段别名:前期小班面积
        [TDDBProperty(Column = "Q_MJ", Index = 125)]
        public double Q_MJ { get; set; }
        //字段别名:前期树种
        [TDDBProperty(Column = "Q_SZ", Index = 126)]
        public string Q_SZ { get; set; }
        //字段别名:前期郁闭度
        [TDDBProperty(Column = "Q_YBD", Index = 127)]
        public double Q_YBD { get; set; }
        //字段别名:前期平均年龄
        [TDDBProperty(Column = "Q_PJNL", Index = 128)]
        public int Q_PJNL { get; set; }
        //字段别名:前期平均胸径
        [TDDBProperty(Column = "Q_PJXJ", Index = 129)]
        public double Q_PJXJ { get; set; }
        //字段别名:前期平均树高
        [TDDBProperty(Column = "Q_PJSG", Index = 130)]
        public double Q_PJSG { get; set; }
        //字段别名:前期公顷断面
        [TDDBProperty(Column = "Q_PJDM", Index = 131)]
        public double Q_PJDM { get; set; }
        //字段别名:前期总蓄积
        [TDDBProperty(Column = "Q_ZXJ", Index = 132)]
        public int Q_ZXJ { get; set; }
        //字段别名:前期伴生树种平均胸径
        [TDDBProperty(Column = "Q_BSSZPJXJ", Index = 133)]
        public double Q_BSSZPJXJ { get; set; }
        //字段别名:前期伴生树种平均年龄
        [TDDBProperty(Column = "Q_BSSZNL", Index = 134)]
        public int Q_BSSZNL { get; set; }
        //字段别名:前期伴生树种平均树高
        [TDDBProperty(Column = "Q_BSSZSG", Index = 135)]
        public double Q_BSSZSG { get; set; }
        //字段别名:前期伴生树种公顷断面
        [TDDBProperty(Column = "Q_BSSZGQDM", Index = 136)]
        public double Q_BSSZGQDM { get; set; }
        //字段别名:前期优势树种蓄积
        [TDDBProperty(Column = "Q_YSSZXJ", Index = 137)]
        public int Q_YSSZXJ { get; set; }
        //字段别名:前期伴生树种蓄积
        [TDDBProperty(Column = "Q_BSSZXJ", Index = 138)]
        public int Q_BSSZXJ { get; set; }
        //字段别名:前期散生蓄积
        [TDDBProperty(Column = "Q_SSXJ", Index = 139)]
        public int Q_SSXJ { get; set; }
        //字段别名:更新备用字段1
        [TDDBProperty(Column = "GX_SPARE1", Index = 140)]
        public string GX_SPARE1 { get; set; }
        //字段别名:更新备用字段2
        [TDDBProperty(Column = "GX_SPARE2", Index = 141)]
        public string GX_SPARE2 { get; set; }
        //字段别名:数据来源
        [TDDBProperty(Column = "DT_SRC", Index = 142)]
        public string DT_SRC { get; set; }
        //字段别名:图面面积
        [TDDBProperty(Column = "V_TMMJ", Index = 143)]
        public double V_TMMJ { get; set; }
        //字段别名:用地种类
        [TDDBProperty(Column = "YDZL", Index = 144)]
        public string YDZL { get; set; }
    }
}
