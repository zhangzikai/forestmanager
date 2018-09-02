using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.orm;

namespace td.db.mid.sys
{

    [TDDBRecord(Table = "T_EditTask")]
    public class T_EDITTASK_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }
        //字段别名:
        [TDDBProperty(Column = "taskname", Index = 1)]
        public string taskname { get; set; }
        //字段别名:
        [TDDBProperty(Column = "datasetname", Index = 2)]
        public string datasetname { get; set; }
        //字段别名:
        [TDDBProperty(Column = "layername", Index = 3)]
        public string layername { get; set; }
        //字段别名:
        [TDDBProperty(Column = "EditState", Index = 4)]
        public string EditState { get; set; }
        //字段别名:
        [TDDBProperty(Column = "logiccheckstate", Index = 5)]
        public string logiccheckstate { get; set; }
        //字段别名:
        [TDDBProperty(Column = "toplogiccheckstate", Index = 6)]
        public string toplogiccheckstate { get; set; }
    }
}
