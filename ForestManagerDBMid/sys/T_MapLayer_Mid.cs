using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "T_MapLayer")]
    public class T_MapLayer_Mid
    {

        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:
        [TDDBProperty(Column = "code", Index = 1)]
        public string code { get; set; }
        //字段别名:
        [TDDBProperty(Column = "datasetname", Index = 2)]
        public string datasetname { get; set; }

        //字段别名:
        [TDDBProperty(Column = "classname", Index = 3)]
        public string classname { get; set; }

        //字段别名:
        [TDDBProperty(Column = "groupname", Index = 4)]
        public string groupname { get; set; }

        //字段别名:
        [TDDBProperty(Column = "keyname", Index = 5)]
        public string keyname { get; set; }

        //字段别名:
        [TDDBProperty(Column = "layername", Index =6)]
        public string layername { get; set; }

        //字段别名:
        [TDDBProperty(Column = "yearflag", Index = 7)]
        public string yearflag { get; set; }
    }
}
