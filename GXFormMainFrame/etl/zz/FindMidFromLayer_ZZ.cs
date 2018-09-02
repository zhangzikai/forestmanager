using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.db.gis;
using td.db.mid.forest;
using td.forest.ldzy.tj;

namespace GXFormMainFrame.etl.zz
{
    /// <summary>
    /// 对征占用图层进行查询：
    /// </summary>
    public class FindMidFromLayer_ZZ : FindMidFromLayer_Base<ZT_LDZZ_2016_Mid>
    {
        /// <summary>
        /// 查询征占用图层中符合字段的数据。
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public override List<ZT_LDZZ_2016_Mid> Find(string fields, string where, string orderby)
        {
            return CreateQueryDef(fields, where, orderby);
        }
    }
}
