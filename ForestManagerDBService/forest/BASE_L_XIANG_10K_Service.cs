﻿using System;
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
public class BASE_L_XIANG_10K_Service
{
 private TDDBServiceBase<BASE_L_XIANG_10K_Mid> m_service;
 public BASE_L_XIANG_10K_Service()
{
m_service =DBServiceFactory.Single.GetService<BASE_L_XIANG_10K_Mid>();
}
public bool IsExist(int id)
{
return m_service.Exist(id);
}
public bool IsExist(string id)
{
return m_service.Exist(id);
}
 public  BASE_L_XIANG_10K_Mid Find(int id)
{
return m_service.Find(id);
}
 public  BASE_L_XIANG_10K_Mid Find(string id)
{
return m_service.Find(id);
}
 public  IList<BASE_L_XIANG_10K_Mid> FindBySql(string sql)
{
return m_service.FindBySql(sql);
}
 public  BASE_L_XIANG_10K_Mid FindOneBySql(string sql)
{
return m_service.FindOneBySql(sql);
}
 public  IList<BASE_L_XIANG_10K_Mid> FindAll()
{
return m_service.FindAll();
}
 public bool Add(BASE_L_XIANG_10K_Mid mid)
{
return m_service.Add(mid);
}
 public bool Add(IList<BASE_L_XIANG_10K_Mid> midLst)
{
return m_service.Add(midLst);
}
 public bool Edit(BASE_L_XIANG_10K_Mid mid)
{
return m_service.Edit(mid);
}
 public bool Edit(IList<BASE_L_XIANG_10K_Mid> midLst)
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