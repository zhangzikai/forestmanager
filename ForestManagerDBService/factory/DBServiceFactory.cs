using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.orm;
using td.db.orm.mssql;
using td.db.orm.sqlite;

namespace td.db.service.factory
{
    public class DBServiceFactory
    {
        private static DBServiceFactory s_service;
        private static object s_lock = new object();
        public static DBServiceFactory Single
        {
            get
            {
                if (null != s_service)
                {
                    return s_service;
                }
                lock (s_lock)
                {
                    if (null == s_service)
                    {
                        s_service = new DBServiceFactory();
                    }
                }
                return s_service;
            }
        }        
        public DBServiceFactory()
        {
            DBType = "MSSqlServer";
        }
        public string DBType { get; set; }
        public TDDBServiceBase<T> GetService<T>() where T : new()
        {
            if(DBType=="MSSqlServer")
            {
                return new TDMSSqlDBServiceBase<T>();
            }
            else if(DBType == "Sqlite")
            {
                return new TDSqliteDBServiceBase<T>();
            }
            else
            {
                return new TDSqliteDBServiceBase<T>();
            }
        }
    }
}
