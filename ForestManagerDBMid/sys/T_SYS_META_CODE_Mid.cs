using System;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "T_SYS_META_CODE")]
    public class T_SYS_META_CODE_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:父代码
        [TDDBProperty(Column = "PCODE", Index = 1)]
        public string PCODE { get; set; }
        //字段别名:代码
        [TDDBProperty(Column = "CCODE", Index = 2)]
        public string CCODE { get; set; }
        //字段别名:名称
        [TDDBProperty(Column = "CNAME", Index = 3)]
        public string CNAME { get; set; }
        //字段别名:简称
        [TDDBProperty(Column = "CSNAME", Index = 4)]
        public string CSNAME { get; set; }
        //字段别名:代码类型
        [TDDBProperty(Column = "CTYPE", Index = 5)]
        public string CTYPE { get; set; }
        //字段别名:代码分类
        [TDDBProperty(Column = "CCATOG", Index = 6)]
        public string CCATOG { get; set; }
        //字段别名:SDE域
        [TDDBProperty(Column = "CDOMAIN", Index = 7)]
        public string CDOMAIN { get; set; }
        //字段别名:额外信息
        [TDDBProperty(Column = "CEXTINF", Index = 8)]
        public string CEXTINF { get; set; }
        //字段别名:代码索引
        [TDDBProperty(Column = "CINDEX", Index = 9)]
        public string CINDEX { get; set; }
        //字段别名:年度
        [TDDBProperty(Column = "CYEAR", Index = 10)]
        public int CYEAR { get; set; }
        //字段别名:代码长度
        [TDDBProperty(Column = "CLEN", Index = 11)]
        public int CLEN { get; set; }

        public string Value
        {
            get { return CCODE; }
        }
        public string Text
        {
            get { return CNAME; }
        }
        public override string ToString()
        {
            return CNAME;
        }
    }
}
