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
public class ZT_CF_2016_Service
{
 private TDDBServiceBase<ZT_CF_Mid> m_service;
 public ZT_CF_2016_Service()
{
m_service =DBServiceFactory.Single.GetService<ZT_CF_Mid>();
}
public bool IsExist(int id)
{
return m_service.Exist(id);
}
public bool IsExist(string id)
{
return m_service.Exist(id);
}
 public  ZT_CF_Mid Find(int id)
{
return m_service.Find(id);
}
 public  ZT_CF_Mid Find(string id)
{
return m_service.Find(id);
}
 public  IList<ZT_CF_Mid> FindBySql(string sql)
{
return m_service.FindBySql(sql);
}
 public  ZT_CF_Mid FindOneBySql(string sql)
{
return m_service.FindOneBySql(sql);
}
 public  IList<ZT_CF_Mid> FindAll()
{
return m_service.FindAll();
}
 public bool Add(ZT_CF_Mid mid)
{
return m_service.Add(mid);
}
 public bool Add(IList<ZT_CF_Mid> midLst)
{
return m_service.Add(midLst);
}
 public bool Edit(ZT_CF_Mid mid)
{
return m_service.Edit(mid);
}
 public bool Edit(IList<ZT_CF_Mid> midLst)
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
