using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.mid.sys;
using td.db.orm;
using td.db.service.sys;

namespace td.logic.sys
{
    public class PathManager
    {
        private IDictionary<string, T_Path_Mid> m_pathKeyDict;
        public PathManager()
        {
            m_pathKeyDict = new Dictionary<string, T_Path_Mid>();
            Init();
        }
        public T_Path_Service PathService
        {
            get
            {
                return DBServiceFactory<T_Path_Service>.Service;
            }
        }
        private void Init()            
        {
            m_pathKeyDict.Clear();
            var lst=PathService.FindAll();
            foreach(T_Path_Mid mid in lst)
            {
                if(!m_pathKeyDict.ContainsKey(mid.PathKey))
                {
                    m_pathKeyDict.Add(mid.PathKey,mid);
                }               
            }
        }
        public T_Path_Mid Find(string key)
        {
            if (m_pathKeyDict.ContainsKey(key))
            {
                return m_pathKeyDict[key];
            }
            return null;
        }

        public string FindValue(string key)
        {
            if (m_pathKeyDict.ContainsKey(key))
            {
                return m_pathKeyDict[key].PathValue;
            }
            return "";
        }
        public void SaveValue(string key,string value)
        {
            if (m_pathKeyDict.ContainsKey(key))
            {
                m_pathKeyDict[key].PathValue = value;
                PathService.Edit(m_pathKeyDict[key]);
            }
        }
       
    }
}
