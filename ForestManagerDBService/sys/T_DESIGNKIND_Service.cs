using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.mid.sys;
using td.db.orm.mssql;
using td.db.orm.sqlite;
using td.db.orm;
using td.db.service.factory;

namespace td.db.service.sys
{
    public class T_DESIGNKIND_Service
    {
        private TDDBServiceBase<T_DESIGNKIND_Mid> m_service;
        public T_DESIGNKIND_Service()
        {
            m_service = DBServiceFactory.Single.GetService<T_DESIGNKIND_Mid>();
        }
        public bool IsExist(int id)
        {
            return m_service.Exist(id);
        }
        public bool IsExist(string id)
        {
            return m_service.Exist(id);
        }
        public T_DESIGNKIND_Mid Find(int id)
        {
            return m_service.Find(id);
        }
        public T_DESIGNKIND_Mid Find(string id)
        {
            return m_service.Find(id);
        }
        public IList<T_DESIGNKIND_Mid> FindBySql(string sql)
        {
            return m_service.FindBySql(sql);
        }
        public T_DESIGNKIND_Mid FindOneBySql(string sql)
        {
            return m_service.FindOneBySql(sql);
        }
        public T_DESIGNKIND_Mid FindKindCode(string kind, string code)
        {
            string sql = "SELECT '0'+[kind]+[code] as [kindcode],name,code FROM T_DesignKind where (kind ='"+kind+ "'and code like '"+code+ "%') order by code";
            T_DESIGNKIND_Mid mid=FindOneBySql(sql);
            return mid;
        }
        public IList<T_DESIGNKIND_Mid> FindAll()
        {
            return m_service.FindAll();
        }
        public bool Add(T_DESIGNKIND_Mid mid)
        {
            return m_service.Add(mid);
        }
        public bool Add(IList<T_DESIGNKIND_Mid> midLst)
        {
            return m_service.Add(midLst);
        }
        public bool Edit(T_DESIGNKIND_Mid mid)
        {
            return m_service.Edit(mid);
        }
        public bool Edit(IList<T_DESIGNKIND_Mid> midLst)
        {
            return m_service.Add(midLst);
        }
        public int Delete(int id)
        {
            return m_service.Delete(id);
        }
        public int Delete(string id)
        {
            return m_service.Delete(id);
        }
        public int DeleteBySql(string whereSql)
        {
            return m_service.Delete2(whereSql);
        }
    }
}
