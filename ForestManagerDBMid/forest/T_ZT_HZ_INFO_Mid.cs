using System;
using td.db.orm;

namespace td.db.mid.forest
{
    [TDDBRecord(Table = "T_ZT_HZ_INFO")]
    public class T_ZT_HZ_INFO_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:县
        [TDDBProperty(Column = "XIAN", Index = 1)]
        public string XIAN { get; set; }
        //字段别名:乡镇
        [TDDBProperty(Column = "XIANG", Index = 2)]
        public string XIANG { get; set; }
        //字段别名:村
        [TDDBProperty(Column = "CUN", Index = 3)]
        public string CUN { get; set; }
        //字段别名:地名
        [TDDBProperty(Column = "DIMING", Index = 4)]
        public string DIMING { get; set; }
        //字段别名:起火时间
        [TDDBProperty(Column = "QHSJ", Index = 5)]
        public string QHSJ { get; set; }

        public int Year { get { return Convert.ToInt32(QHSJ.Split('-')[0]); } }
        public int Month { get { return Convert.ToInt32(QHSJ.Split('-')[1]); } }
        //字段别名:扑火时间
        [TDDBProperty(Column = "PHSJ", Index = 6)]
        public string PHSJ { get; set; }
        //字段别名:火场总面积（公顷）
        [TDDBProperty(Column = "TOTAL_MJ", Index = 7)]
        public double TOTAL_MJ { get; set; }
        //字段别名:受害原始林面积
        [TDDBProperty(Column = "YSL_MJ", Index = 8)]
        public double YSL_MJ { get; set; }
        //字段别名:受害人工林面积
        [TDDBProperty(Column = "RGL_MJ", Index = 9)]
        public double RGL_MJ { get; set; }
        //字段别名:林分组成
        [TDDBProperty(Column = "LINFEN", Index = 10)]
        public string LINFEN { get; set; }
        //字段别名:成林损失蓄积
        [TDDBProperty(Column = "SS_CL", Index = 11)]
        public double SS_CL { get; set; }
        //字段别名:幼林损失株数
        [TDDBProperty(Column = "SS_YL", Index = 12)]
        public int SS_YL { get; set; }
        //字段别名:受害新造林地面积
        [TDDBProperty(Column = "SS_ZLMJ", Index = 13)]
        public double SS_ZLMJ { get; set; }
        //字段别名:轻伤人数
        [TDDBProperty(Column = "SHANG_Q", Index = 14)]
        public int SHANG_Q { get; set; }
        //字段别名:重伤人数
        [TDDBProperty(Column = "SHANG_Z", Index = 15)]
        public int SHANG_Z { get; set; }
        //字段别名:死亡人数
        [TDDBProperty(Column = "SHANG_S", Index = 16)]
        public int SHANG_S { get; set; }
        //字段别名:其他损失折款
        [TDDBProperty(Column = "SS_MONEY", Index = 17)]
        public double SS_MONEY { get; set; }
        //字段别名:出动扑火人工
        [TDDBProperty(Column = "PU_RG", Index = 18)]
        public int PU_RG { get; set; }
        //字段别名:出动车辆
        [TDDBProperty(Column = "PU_CL", Index = 19)]
        public int PU_CL { get; set; }
        //字段别名:出动汽车
        [TDDBProperty(Column = "PU_QC", Index = 20)]
        public int PU_QC { get; set; }
        //字段别名:出动飞机
        [TDDBProperty(Column = "PU_FJ", Index = 21)]
        public int PU_FJ { get; set; }
        //字段别名:扑火经费（万元）
        [TDDBProperty(Column = "PU_JF", Index = 22)]
        public double PU_JF { get; set; }
        //字段别名:是否已经处理
        [TDDBProperty(Column = "SF_CL", Index = 23)]
        public string SF_CL { get; set; }
        //字段别名:处理人数
        [TDDBProperty(Column = "CL_RS", Index = 24)]
        public int CL_RS { get; set; }
        //字段别名:处理刑事处罚人数
        [TDDBProperty(Column = "CL_XSRS", Index = 25)]
        public int CL_XSRS { get; set; }
        //字段别名:火灾原因
        [TDDBProperty(Column = "HZYY", Index = 26)]
        public string HZYY { get; set; }
        //字段别名:火灾编号
        [TDDBProperty(Column = "FIRE_NO", Index = 27)]
        public string FIRE_NO { get; set; }
        //字段别名:火灾等级
        [TDDBProperty(Column = "HZDJ", Index = 28)]
        public string HZDJ { get; set; }
        //字段别名:林龄
        [TDDBProperty(Column = "林龄", Index = 29)]
        public string NL { get; set; }

        public int HZDJ_I { get { return Convert.ToInt32(HZDJ); } }
    }
}
