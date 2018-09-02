using System;
using td.db.orm;

namespace td.db.mid.sys
{
    [TDDBRecord(Table = "T_SYS_FLOW_USER")]
    public class T_SYS_FLOW_USER_Mid
    {
        [TDDBPrimaryKey(Column = "ID", PrimaryType = "AutoCreate")]
        public int ID { get; set; }

        //字段别名:用户姓名
        [TDDBProperty(Column = "USER_NAME", Index = 2)]
        public string USER_NAME { get; set; }
        //字段别名:用户密码
        [TDDBProperty(Column = "USER_PASSWORD", Index = 3)]
        public string USER_PASSWORD { get; set; }
        //字段别名:用户说明
        [TDDBProperty(Column = "USER_NOTE", Index = 4)]
        public string USER_NOTE { get; set; }
        //字段别名:用户创建日期
        [TDDBProperty(Column = "CREATE_TIME", Index = 5)]
        public DateTime CREATE_TIME { get; set; }
        //字段别名:用户性别
        [TDDBProperty(Column = "USER_SEX", Index = 6)]
        public string USER_SEX { get; set; }
        //字段别名:用户电话
        [TDDBProperty(Column = "USER_PHONE", Index = 7)]
        public string USER_PHONE { get; set; }
        //字段别名:电子邮件
        [TDDBProperty(Column = "USER_EMAIL", Index = 8)]
        public string USER_EMAIL { get; set; }
        //字段别名:所属部门
        [TDDBProperty(Column = "USER_DEPT", Index = 9)]
        public int USER_DEPT { get; set; }

        public bool IsManager { get; set; }
    }
}
