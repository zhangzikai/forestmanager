namespace EarthBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class LindResultQuery
    {
      

        public List<PointLabel> PointsAdd
        {
            get;
            set;
        }

        public List<PointLabel> PointsPlus
        {
            get;
            set;
        }

        public string TotalInfor
        {
            get;
            set;
        }

        public DataTable XBAdd
        {
            get;
            set;
        }

        public DataTable XBPlus
        {
            get;
            set;
        }
    }
}

