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
public class FOR_XIAOBAN_2015_Service
{
 private TDDBServiceBase<FOR_XIAOBAN_2015_Mid> m_service;
 public FOR_XIAOBAN_2015_Service()
{
m_service =DBServiceFactory.Single.GetService<FOR_XIAOBAN_2015_Mid>();
}
public bool IsExist(int id)
{
return m_service.Exist(id);
}
public bool IsExist(string id)
{
return m_service.Exist(id);
}
 public  FOR_XIAOBAN_2015_Mid Find(int id)
{
return m_service.Find(id);
}
 public  FOR_XIAOBAN_2015_Mid Find(string id)
{
return m_service.Find(id);
}
 public  IList<FOR_XIAOBAN_2015_Mid> FindBySql(string sql)
{
return m_service.FindBySql(sql);
}
 public  FOR_XIAOBAN_2015_Mid FindOneBySql(string sql)
{
return m_service.FindOneBySql(sql);
}
 public  IList<FOR_XIAOBAN_2015_Mid> FindAll()
{
return m_service.FindAll();
}
 public bool Add(FOR_XIAOBAN_2015_Mid mid)
{
return m_service.Add(mid);
}
 public bool Add(IList<FOR_XIAOBAN_2015_Mid> midLst)
{
return m_service.Add(midLst);
}
 public bool Edit(FOR_XIAOBAN_2015_Mid mid)
{
return m_service.Edit(mid);
}
 public bool Edit(IList<FOR_XIAOBAN_2015_Mid> midLst)
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
