using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "T_SYS_DB_INFO")]
    public class T_SYS_DB_INFO_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //项目
        [TDDBProperty(Column = "V_ITEM", Index = 1)]
        public string V_ITEM { get; set; }
        //值
        [TDDBProperty(Column = "V_VALUE", Index = 2)]
        public string V_VALUE { get; set; }
        //注记
        [TDDBProperty(Column = "V_MEMO", Index = 3)]
        public string V_MEMO { get; set; }
    }
}
