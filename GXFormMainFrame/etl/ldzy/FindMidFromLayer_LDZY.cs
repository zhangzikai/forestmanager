using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.forest.ldzy.tj;

namespace td.db.etl.ldzy
{
    public class FindMidFromLayer_LDZY : FindMidFromLayer_Base<Forest_LDZY_Mid>
    {
        public override List<Forest_LDZY_Mid> Find(string fields, string where, string orderby)
        {
            return CreateQueryDef(fields, where, orderby);
        }
    }
}
