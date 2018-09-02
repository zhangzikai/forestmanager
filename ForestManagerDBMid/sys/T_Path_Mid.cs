using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.orm;

namespace td.db.mid.sys
{
     [TDDBRecord(Table = "T_Path")]
    public class T_Path_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        [TDDBProperty(Column = "EditKind", Index = 1)]
        public string EditKind { get; set; }


        //字段别名:
        [TDDBProperty(Column = "PathKey", Index = 2)]
        public string PathKey { get; set; }
        //字段别名:
        [TDDBProperty(Column = "PathName", Index = 3)]
        public string PathName { get; set; }

        //字段别名:
        [TDDBProperty(Column = "PathValue", Index = 4)]
        public string PathValue { get; set; }

        //字段别名:
        [TDDBProperty(Column = "Note", Index = 5)]
        public string Note { get; set; }
    }
}
