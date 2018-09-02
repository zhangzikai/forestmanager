using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.mid.forest;
using td.db.orm.mssql;
using td.db.orm.sqlite;
using td.db.orm;
using td.db.service.factory;

namespace td.db.service.forest
{
public class FOR_XBBH_2016_Service
{
 private TDDBServiceBase<FOR_XBBH_2016_Mid> m_service;
 public FOR_XBBH_2016_Service()
{
m_service =DBServiceFactory.Single.GetService<FOR_XBBH_2016_Mid>();
}
public bool IsExist(int id)
{
return m_service.Exist(id);
}
public bool IsExist(string id)
{
return m_service.Exist(id);
}
 public  FOR_XBBH_2016_Mid Find(int id)
{
return m_service.Find(id);
}
 public  FOR_XBBH_2016_Mid Find(string id)
{
return m_service.Find(id);
}
 public  IList<FOR_XBBH_2016_Mid> FindBySql(string sql)
{
return m_service.FindBySql(sql);
}
 public  FOR_XBBH_2016_Mid FindOneBySql(string sql)
{
return m_service.FindOneBySql(sql);
}
 public  IList<FOR_XBBH_2016_Mid> FindAll()
{
return m_service.FindAll();
}
 public bool Add(FOR_XBBH_2016_Mid mid)
{
return m_service.Add(mid);
}
 public bool Add(IList<FOR_XBBH_2016_Mid> midLst)
{
return m_service.Add(midLst);
}
 public bool Edit(FOR_XBBH_2016_Mid mid)
{
return m_service.Edit(mid);
}
 public bool Edit(IList<FOR_XBBH_2016_Mid> midLst)
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
