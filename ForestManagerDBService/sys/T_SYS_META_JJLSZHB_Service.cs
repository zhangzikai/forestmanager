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
public class T_SYS_META_JJLSZHB_Service
{
 private TDDBServiceBase<T_SYS_META_JJLSZHB_Mid> m_service;
 public T_SYS_META_JJLSZHB_Service()
{
m_service =DBServiceFactory.Single.GetService<T_SYS_META_JJLSZHB_Mid>();
}
public bool IsExist(int id)
{
return m_service.Exist(id);
}
public bool IsExist(string id)
{
return m_service.Exist(id);
}
 public  T_SYS_META_JJLSZHB_Mid Find(int id)
{
return m_service.Find(id);
}
 public  T_SYS_META_JJLSZHB_Mid Find(string id)
{
return m_service.Find(id);
}
 public  IList<T_SYS_META_JJLSZHB_Mid> FindBySql(string sql)
{
return m_service.FindBySql(sql);
}
 public  T_SYS_META_JJLSZHB_Mid FindOneBySql(string sql)
{
return m_service.FindOneBySql(sql);
}
 public  IList<T_SYS_META_JJLSZHB_Mid> FindAll()
{
return m_service.FindAll();
}
 public bool Add(T_SYS_META_JJLSZHB_Mid mid)
{
return m_service.Add(mid);
}
 public bool Add(IList<T_SYS_META_JJLSZHB_Mid> midLst)
{
return m_service.Add(midLst);
}
 public bool Edit(T_SYS_META_JJLSZHB_Mid mid)
{
return m_service.Edit(mid);
}
 public bool Edit(IList<T_SYS_META_JJLSZHB_Mid> midLst)
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
public int   DeleteBySql(string whereSql)
{
return m_service.Delete2(whereSql);
}
}
}
