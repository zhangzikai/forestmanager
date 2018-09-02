using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.orm;

namespace td.db.service.factory
{
    public class DBServiceBase<T> where T : new()
    {
        protected TDDBServiceBase<T> m_service;
        public DBServiceBase()
        {
            m_service = DBServiceFactory.Single.GetService<T>();
        }
        public virtual string TableName
        {
            get { return m_service.TableName; }
        }
        public int TotalCount
        {
            get
            {
                return m_service.Count();
            }
        }
        public int Count(string whereSql)
        {            
            return m_service.Count(whereSql);            
        }
        public  IList<T> FindByPage(int fromPage, int pageSize, string wheresql, string orderSql)
        {
            return m_service.FindByPage(fromPage, pageSize, wheresql, orderSql);           
        }
        public bool IsExist(int id)
        {
            return m_service.Exist(id);
        }
        public bool IsExist(string id)
        {
            return m_service.Exist(id);
        }
        public T Find(int id)
        {
            return m_service.Find(id);
        }
        public T Find(string id)
        {
            return m_service.Find(id);
        }
        public IList<T> FindBySql(string sql)
        {
            return m_service.FindBySql(sql);
        }
        public T FindOneBySql(string sql)
        {
            return m_service.FindOneBySql(sql);
        }
        public IList<T> FindAll()
        {
            return m_service.FindAll();
        }
        public bool Add(T mid)
        {
            return m_service.Add(mid);
        }
        public bool Add(IList<T> midLst)
        {
            return m_service.Add(midLst);
        }
        public bool Edit(T mid)
        {
            return m_service.Edit(mid);
        }
        public bool Edit(IList<T> midLst)
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
            return m_service.Delete(whereSql);
        }
        public int DeleteAll()
        {
            return m_service.Delete("1=1");
        }
        public int ExecuteSql(string sql)
        {
            return m_service.ExectNoneQuerySql(sql);
        }
        public IList<string> ExecuteReaderSql(string sql)
        {
            Tuple<bool, IList<string>> res = m_service.ExectReaderListSql(sql);
            if (res.Item1) return res.Item2;
            return new List<string>();
        }
        public IList<IList<string>> ExecuteReaderSql(string sql,int colCount)
        {
            Tuple<bool, IList<IList<string>>> res = m_service.ExectReaderListSql(sql,colCount);
            if (res.Item1) return res.Item2;
            return null;
        }
    }
}
