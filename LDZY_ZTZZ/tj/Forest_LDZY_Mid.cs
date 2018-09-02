using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace td.forest.ldzy.tj
{
    public class Forest_LDZY_Mid
    {
        public string SHI { get; set; }
        public string XIAN { get; set; }
        public string XIANG { get; set; }
        public string CUN { get; set; }

        public string Q_LD_QS { get; set; }
        public string LDQS { get { return Q_LD_QS; } }

        public string Q_DI_LEI { get; set; }
        public string TDZL { get { return Q_DI_LEI; } }

        public string LDLX { get; set; }
        public string SHI_QUAN_D { get; set; }


        public string SQJ { get { return SHI_QUAN_D; } }

        public double MIAN_JI { get; set; }
        /// <summary>
        /// 森林蓄积
        /// </summary>
        public string SLXJ { get; set; }
        public string XMBH { get; set; }
        public string YDZL { get; set; }
       
        
    }
}
