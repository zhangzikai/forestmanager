using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.mid.sys;
using td.db.service.factory;

namespace td.db.service.sys
{
    public class T_SYS_DB_INFO_Service : DBServiceBase<T_SYS_DB_INFO_Mid>
    {
        public T_SYS_DB_INFO_Service():base()
        {
            
        }
        public string FindDBValueByItem(string item)
        {
          T_SYS_DB_INFO_Mid mid=  this.m_service.FindOneBySql("V_ITEM='"+item+"'");
          if (null == mid) return "";
          return mid.V_VALUE;
        }
       
    }
}
