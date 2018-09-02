using System;
using td.db.orm;

namespace td.db.mid.sys
{
    /// <summary>
    /// 元数据表在此定义
    /// </summary>
    [TDDBRecord(Table = "T_SYS_META_FIELDS")]
    public class T_SYS_META_FIELDS_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:表编号
        [TDDBProperty(Column = "TAB_ID", Index = 1)]
        public string TAB_ID { get; set; }
        //字段别名:字段名
        [TDDBProperty(Column = "FIEL_NA", Index = 2)]
        public string FIEL_NA { get; set; }
        //字段别名:字段别名
        [TDDBProperty(Column = "FIEL_AL", Index = 3)]
        public string FIEL_AL { get; set; }
        //字段别名:字段序号
        [TDDBProperty(Column = "FIEL_IND", Index = 4)]
        public double FIEL_IND { get; set; }
        //字段别名:字段类型
        [TDDBProperty(Column = "FIEL_TY", Index = 5)]
        public string FIEL_TY { get; set; }
        //字段别名:字段精度
        [TDDBProperty(Column = "FIEL_SCA", Index = 6)]
        public string FIEL_SCA { get; set; }
        //字段别名:字段单位
        [TDDBProperty(Column = "FIEL_UNI", Index = 7)]
        public string FIEL_UNI { get; set; }
        //字段别名:代码表
        [TDDBProperty(Column = "CTABLE", Index = 8)]
        public string CTABLE { get; set; }
        //字段别名:代码索引
        [TDDBProperty(Column = "CODE_IND", Index = 9)]
        public string CODE_IND { get; set; }
        //字段别名:是否为名称字段
        [TDDBProperty(Column = "ISNACOL", Index = 10)]
        public string ISNACOL { get; set; }
        //字段别名:是否主键
        [TDDBProperty(Column = "ISINDEX", Index = 11)]
        public string ISINDEX { get; set; }
        //字段别名:是否必填
        [TDDBProperty(Column = "ISFULL", Index = 12)]
        public string ISFULL { get; set; }
        //字段别名:逻辑关系
        [TDDBProperty(Column = "FIEL_LOG", Index = 13)]
        public string FIEL_LOG { get; set; }
        //字段别名:是否自增长
        [TDDBProperty(Column = "ISAUTO", Index = 14)]
        public string ISAUTO { get; set; }
        //字段别名:额外信息
        [TDDBProperty(Column = "FIEL_EXT", Index = 15)]
        public string FIEL_EXT { get; set; }
    }
}
