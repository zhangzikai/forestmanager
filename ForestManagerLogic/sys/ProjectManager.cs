using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.mid.sys;
using td.db.orm;
using td.db.service.sys;

namespace td.logic.sys
{
    public class ProjectManager
    {
        public ProjectManager() { }

        public T_EDITTASK_Service TaskMetaService
        {
            get { return DBServiceFactory<T_EDITTASK_Service>.Service; }
        }
        public T_EDITTASK_ZT_Service TaskService
        {
            get { return DBServiceFactory<T_EDITTASK_ZT_Service>.Service; }
        }
        public T_DESIGNKIND_Service DKService
        {
            get { return DBServiceFactory<T_DESIGNKIND_Service>.Service; }
        }

        public IList<T_EDITTASK_ZT_Mid> FindByKindCode(string kindCode)
        {
            string sql = "taskkind like '0" + kindCode + "%'";
            return DBServiceFactory<T_EDITTASK_ZT_Service>.Service.FindBySql(sql);
        }

        public IList<T_EDITTASK_ZT_Mid> FindBySql(string whereSql)
        {
           
            return DBServiceFactory<T_EDITTASK_ZT_Service>.Service.FindBySql(whereSql);
        }
        public  IList<T_DESIGNKIND_Mid> FindTreeByKindCode(string kindCode)
        {
            string sql = " kind= " + kindCode;
            List<T_DESIGNKIND_Mid> allLst = DKService.FindBySql(sql) as List<T_DESIGNKIND_Mid>;
            IList<T_DESIGNKIND_Mid> rootLst = new List<T_DESIGNKIND_Mid>();
            var root=allLst.Where(p => p.code.Substring(2, 4) == "0000");
            foreach (T_DESIGNKIND_Mid mid in root)
            {
                 rootLst.Add(mid);
                 mid.SubList =new List<T_DESIGNKIND_Mid>();
                 foreach(T_DESIGNKIND_Mid mid2 in allLst.Where(p => p.code.Substring(0, 2) == mid.code.Substring(0, 2)&&p.code.Substring(4,2)=="00"))
                 {
                     mid.SubList.Add(mid2);
                     mid2.SubList = new List<T_DESIGNKIND_Mid>();
                     foreach (T_DESIGNKIND_Mid mid3 in allLst.Where(p => p.code.Substring(0, 4) == mid2.code.Substring(0, 4)&&p.code.Substring(4,2)!="00"))
                     {
                         mid2.SubList.Add(mid3);
                     }
                 }
            }
            return rootLst;
        }
        public IList<T_DESIGNKIND_Mid> FindSecondTreeByKindCode(string kindCode)
        {
            string sql = " kind= " + kindCode;
            List<T_DESIGNKIND_Mid> allLst = DKService.FindBySql(sql) as List<T_DESIGNKIND_Mid>;
              
        IList<T_DESIGNKIND_Mid> rootLst = new List<T_DESIGNKIND_Mid>();
        foreach (T_DESIGNKIND_Mid mid2 in allLst.Where(p => p.code.Substring(0, 2) == kindCode.Substring(0, 2) && p.code.Substring(4, 2) == "00"))
                {
                    rootLst.Add(mid2);
                    mid2.SubList = new List<T_DESIGNKIND_Mid>();
                    foreach (T_DESIGNKIND_Mid mid3 in allLst.Where(p => p.code.Substring(0, 4) == mid2.code.Substring(0, 4) && p.code.Substring(4, 2) != "00"))
                    {
                        mid2.SubList.Add(mid3);
                    }
                }
            
            return rootLst;
        }
        public IList<T_DESIGNKIND_Mid> FindThirdTreeByKindCode(string kindCode)
        {
            string sql = " kind= " + kindCode;
            List<T_DESIGNKIND_Mid> allLst = DKService.FindBySql(sql) as List<T_DESIGNKIND_Mid>;
            IList<T_DESIGNKIND_Mid> rootLst = new List<T_DESIGNKIND_Mid>();                  
            foreach (T_DESIGNKIND_Mid mid3 in allLst.Where(p => p.code.Substring(0, 4) == kindCode.Substring(0, 4) && p.code.Substring(4, 2) != "00"))
            {
                rootLst.Add(mid3);
            }           

            return rootLst;
        }
        public IList<T_DESIGNKIND_Mid> FindByKindAndCode(string code, string kind)
        {
            string sql = "code = '" + code + "' and kind='" + kind + "'";
            return DBServiceFactory<T_DESIGNKIND_Service>.Service.FindBySql(sql);
        }
        public IList<T_DESIGNKIND_Mid> FindDKByKindCode(string kindCode)
        {

            return DBServiceFactory<T_DESIGNKIND_Service>.Service.FindBySql("kind='" + kindCode + "'");
        }
        //public IList<T_DESIGNKIND_Mid> FindDKBySql(string sql)
        //{

        //    return DBServiceFactory<T_DESIGNKIND_Service>.Service.FindBySql(sql);
        //}
        public bool Delete(int id)
        {
            return DBServiceFactory<T_EDITTASK_ZT_Service>.Service.Delete(id)>0;
        }
        public bool Delete(string sql)
        {
            return DBServiceFactory<T_EDITTASK_ZT_Service>.Service.DeleteBySql(sql) > 0;
        }
        public bool EditTaskName(int id,string name)
        {
           T_EDITTASK_ZT_Mid mid= DBServiceFactory<T_EDITTASK_ZT_Service>.Service.Find(id);
           mid.taskname = name;
          return DBServiceFactory<T_EDITTASK_ZT_Service>.Service.Edit(mid);
        }
        public bool EditTaskNameAndPath(int id, string name,string path)
        {
            T_EDITTASK_ZT_Mid mid = DBServiceFactory<T_EDITTASK_ZT_Service>.Service.Find(id);
            mid.taskname = name;
            mid.taskpath = path;
            return DBServiceFactory<T_EDITTASK_ZT_Service>.Service.Edit(mid);
        }
    }
}
