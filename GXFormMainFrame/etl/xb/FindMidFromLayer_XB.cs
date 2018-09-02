using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.db.mid.forest;

namespace td.db.etl.xb
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMidFromLayer_XB : FindMidFromLayer_Base<FOR_XIAOBAN_Mid>
    {

        public override List<FOR_XIAOBAN_Mid> Find(string fields, string where, string orderby)
        {
            return CreateQueryDef(fields, where, orderby);
        }
    }
}
