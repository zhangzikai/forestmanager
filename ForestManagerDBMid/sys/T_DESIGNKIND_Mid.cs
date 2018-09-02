using System;
using System.Collections.Generic;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "T_DESIGNKIND")]
    public class T_DESIGNKIND_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:
        [TDDBProperty(Column = "code", Index = 1)]
        public string code { get; set; }
        //字段别名:
        [TDDBProperty(Column = "name", Index = 2)]
        public string name { get; set; }
        //字段别名:
        [TDDBProperty(Column = "kind", Index = 3)]
        public string kind { get; set; }

        public string kindCode
        {
            get
            {
                return "0" + kind + code;
            }
        }
        public IList<T_DESIGNKIND_Mid> SubList { get; set; }
    }
}
