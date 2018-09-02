using System;
using System.Collections.Generic;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "T_EDITTASK_ZT")]
    public class T_EDITTASK_ZT_Mid:td.db.orm.TDMidBase
    {

       public T_EDITTASK_ZT_Mid()
        {
            this.taskpath = "";
            this.logiccheckstate = "0";
            this.bh = "";
            this.toplogiccheckstate = "0";
            this.taskstate = "1";
        }
        //字段别名:
        [TDDBProperty(Column = "taskname", Index = 1)]
        public string taskname { get; set; }
        //字段别名:
        [TDDBProperty(Column = "taskkind", Index = 2)]
        public string taskkind { get; set; }
        //字段别名:
        [TDDBProperty(Column = "distcode", Index = 3)]
        public string distcode { get; set; }
        //字段别名:
        [TDDBProperty(Column = "taskstate", Index = 4)]
        public string taskstate { get; set; }
        //字段别名:
        [TDDBProperty(Column = "taskpath", Index = 5)]
        public string taskpath { get; set; }
        //字段别名:
        [TDDBProperty(Column = "taskyear", Index = 6)]
        public string taskyear { get; set; }
        //字段别名:
        [TDDBProperty(Column = "createtime", Index = 7)]
        public string createtime { get; set; }
        //字段别名:
        [TDDBProperty(Column = "datasetname", Index = 8)]
        public string datasetname { get; set; }
        //字段别名:
        [TDDBProperty(Column = "layername", Index = 9)]
        public string layername { get; set; }
        //字段别名:
        [TDDBProperty(Column = "edittime", Index = 10)]
        public string edittime { get; set; }
        //字段别名:
        [TDDBProperty(Column = "logiccheckstate", Index = 11)]
        public string logiccheckstate { get; set; }
        //字段别名:
        [TDDBProperty(Column = "toplogiccheckstate", Index = 12)]
        public string toplogiccheckstate { get; set; }
        //字段别名:
        [TDDBProperty(Column = "tablename", Index = 13)]
        public string tablename { get; set; }
        //字段别名:
        [TDDBProperty(Column = "bh", Index = 14)]
        public string bh { get; set; }

        public IList<T_EDITTASK_ZT_Mid> SubList { get; set; }
    }
}
