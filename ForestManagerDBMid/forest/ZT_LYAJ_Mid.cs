using System;
using td.db.orm;

namespace td.db.mid.forest
{
    [TDDBRecord(Table = "ZT_LYAJ")]
    public class ZT_LYAJ_Mid
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
        //字段别名:林班
        [TDDBProperty(Column = "LIN_BAN", Index = 6)]
        public string LIN_BAN { get; set; }
        //字段别名:图斑（小班）
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
        //字段别名:每公顷株数
        [TDDBProperty(Column = "MEI_GQ_ZS", Index = 24)]
        public int MEI_GQ_ZS { get; set; }
        //字段别名:保留蓄积
        [TDDBProperty(Column = "BLXJ", Index = 25)]
        public int BLXJ { get; set; }
        //字段别名:更新时间
        [TDDBProperty(Column = "GXSJ", Index = 26)]
        public string GXSJ { get; set; }
        //字段别名:案件类型
        [TDDBProperty(Column = "AJLX", Index = 27)]
        public string AJLX { get; set; }
        //字段别名:行为主体
        [TDDBProperty(Column = "XWZT", Index = 28)]
        public string XWZT { get; set; }
        //字段别名:损失林地面积
        [TDDBProperty(Column = "SSLDMJ", Index = 29)]
        public double SSLDMJ { get; set; }
        //字段别名:损失林木蓄积
        [TDDBProperty(Column = "SSLMXJ", Index = 30)]
        public int SSLMXJ { get; set; }
        //字段别名:损失林木株数
        [TDDBProperty(Column = "SSLMZS", Index = 31)]
        public int SSLMZS { get; set; }
        //字段别名:损失毛竹株数
        [TDDBProperty(Column = "SSMZZS", Index = 32)]
        public int SSMZZS { get; set; }
        //字段别名:损失幼树苗木株数
        [TDDBProperty(Column = "SSYSMMZS", Index = 33)]
        public int SSYSMMZS { get; set; }
        //字段别名:发生日期
        [TDDBProperty(Column = "FSRQ", Index = 34)]
        public string FSRQ { get; set; }

        public string Month
        {
            get
            {
               return FSRQ.Substring(4, 2);
            }
        }
        //字段别名:记录日期
        [TDDBProperty(Column = "JLRQ", Index = 35)]
        public string JLRQ { get; set; }
        //字段别名:优势树种
        [TDDBProperty(Column = "YOU_SHI_SZ", Index = 36)]
        public string YOU_SHI_SZ { get; set; }
    }
}
