using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.db.gis;
using td.db.mid.forest;

namespace td.db.etl.zl
{
    public class FindMidFromTable_HZ : FindMidFromTable_Base<T_ZT_HZ_INFO_Mid>
    {
        public override List<T_ZT_HZ_INFO_Mid> Find(string fields, string where, string orderby)
        {           
            return CreateQueryDef(fields, where,orderby );
        }
    }
}
