using System;
using System.Collections.Generic;
using System.Text;

namespace  td.db.gis
{
    public abstract class FindMidFromLayer
    {
        protected List<Forst_ZL_Mid> m_data;
  
        public FindMidFromLayer()
        {
            m_data = new List<Forst_ZL_Mid>();
        }

        public virtual List<Forst_ZL_Mid> FindShengChan(string subField, string where, string orderby)
        {
            return m_data;
        }
    }
}
