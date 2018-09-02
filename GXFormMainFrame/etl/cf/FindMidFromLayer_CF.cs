using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.db.mid.forest;

namespace td.db.etl.cf
{
    /// <summary>
    /// 查询采伐图层并返回采伐图层指定字段的数据表
    /// </summary>
    public class FindMidFromLayer_CF: FindMidFromLayer_Base<ZT_CF_Mid>
    {
        /// <summary>
        /// 返回采伐图层指定字段的数据表
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public override List<ZT_CF_Mid> Find(string fields, string where, string orderby)
        {
            return CreateQueryDef(fields, where, orderby);
        }
    }
}
