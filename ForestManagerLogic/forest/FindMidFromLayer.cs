using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace td.logic.forest
{
    public class FindMidFromLayer<T> where T : new()
    {
        protected List<T> m_data;  
        public FindMidFromLayer()
        {
            m_data = new List<T>();
        }

        public virtual List<T> Find(string subField, string where, string orderby)
        {
            return m_data;
        }
    }
    }

