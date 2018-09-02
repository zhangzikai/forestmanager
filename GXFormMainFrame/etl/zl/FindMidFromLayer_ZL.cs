using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.etl;
using td.db.gis;

namespace td.db.etl.zl
{
    /// <summary>
    /// 查询造林图层并返回造林图层指定字段的数据表
    /// </summary>
    public class FindMidFromLayer_ZL : FindMidFromLayer_Base<Forst_ZL_Mid>
    {
        /// <summary>
        /// 返回造林图层指定字段的数据表
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public override List<Forst_ZL_Mid> Find(string fields, string where, string orderby)
        {
            return CreateQueryDef(fields, where,orderby );
        }
    }
}
