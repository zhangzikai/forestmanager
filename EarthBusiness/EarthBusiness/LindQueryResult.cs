namespace EarthBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class LindQueryResult
    {
       

        public DataTable CountArea
        {
            get;
            set;
        }

        public List<PointLabel> Points
        {
            get;
            set;
        }

        public DataTable XB
        {
            get;
            set;
        }
    }
}

