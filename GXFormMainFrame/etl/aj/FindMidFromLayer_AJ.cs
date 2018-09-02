using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.db.mid.forest;

namespace td.db.etl.aj
{
    public class FindMidFromLayer_AJ : FindMidFromLayer_Base<ZT_LYAJ_Mid>
    {
        public override List<ZT_LYAJ_Mid> Find(string fields, string where, string orderby)
        {
            return CreateQueryDef(fields, where, orderby);
        }
    }
}
