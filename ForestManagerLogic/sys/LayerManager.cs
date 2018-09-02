using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.mid.sys;
using td.db.orm;
using td.db.service.sys;

namespace td.logic.sys
{
    public class LayerManager
    {
        private IDictionary<string, T_MapLayer_Mid> m_layerKeyDict;
        private IDictionary<string, T_MapLayer_Mid> m_layerGLCDict;
        private IDictionary<string, T_MapLayer_Mid> m_layerGLDict;
        public LayerManager()
        {
            m_layerKeyDict = new Dictionary<string, T_MapLayer_Mid>();
            m_layerGLCDict = new Dictionary<string, T_MapLayer_Mid>();
            m_layerGLDict = new Dictionary<string, T_MapLayer_Mid>();
            Init();
        }
        public T_MapLayer_Service LayerService
        {
            get
            {
                return DBServiceFactory<T_MapLayer_Service>.Service;
            }
        }
        public void Init()
        {
            m_layerKeyDict.Clear();
            m_layerGLCDict.Clear();
            m_layerGLDict.Clear();
            var lst = LayerService.FindAll();
            foreach (T_MapLayer_Mid mid in lst)
            {
                if(!string.IsNullOrWhiteSpace(mid.keyname))
                {
                    if (!m_layerKeyDict.ContainsKey(mid.keyname))
                    {
                        m_layerKeyDict.Add(mid.keyname, mid);
                        //关联字段操作
                    }
                }
                string glcKey = mid.groupname + ":" + mid.layername + ":" + mid.code;                
                if (!m_layerGLCDict.ContainsKey(glcKey))
                {
                    m_layerGLCDict.Add(glcKey, mid);                       
                }
                  string glKey = mid.groupname + ":" + mid.layername;
                  if (!m_layerGLDict.ContainsKey(glKey))
                {
                    m_layerGLDict.Add(glKey, mid);                       
                }
                
                
            }
        }
        public T_MapLayer_Mid FindByGL(string grpName, string lyrName)
        {
            string glKey = grpName + ":" + lyrName;
            if (m_layerGLDict.ContainsKey(glKey))
            {
                return m_layerGLDict[glKey];
            }
            return null;
        }
        public T_MapLayer_Mid FindByGLC(string grpName,string lyrName,string code)
        {
            string glcKey = grpName + ":" + lyrName + ":" + code;
            if (m_layerGLCDict.ContainsKey(glcKey))
            {
                return m_layerGLCDict[glcKey];
            }
            return null;
        }
        public T_MapLayer_Mid FindByKeyName(string keyName)
        {
            if(m_layerKeyDict.ContainsKey(keyName))
            {
                return m_layerKeyDict[keyName];
            }
            return null;
        }





    }
}
