using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace td.forest.ldzy.tj
{
    public class FindMidFromLayer_LDZY
    {
         protected List<Forest_LDZY_Mid> m_data;
  
        public FindMidFromLayer_LDZY()
        {
            m_data = new List<Forest_LDZY_Mid>();
        }

        public virtual List<Forest_LDZY_Mid> Find(string subField, string where, string orderby)
        {
            return m_data;
        }
    }
    
}
