using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.db.mid.forest;

namespace td.db.etl.zh
{
    public class FindMidFromLayer_ZH : FindMidFromLayer_Base<ZT_ZH_Mid>
    {
        public override List<ZT_ZH_Mid> Find(string fields, string where, string orderby)
        {
            return CreateQueryDef(fields, where, orderby);
        }
    }
}
