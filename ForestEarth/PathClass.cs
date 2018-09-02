namespace ForestEarth
{
    using System;
    using System.Collections.Generic;
    using EviaEarthCommonLib;

    internal class PathClass
    {
        private List<S_Vec3Geo> m_points = new List<S_Vec3Geo>();
        private string namesStr;

        public string Name
        {
            get
            {
                return this.namesStr;
            }
            set
            {
                this.namesStr = value;
            }
        }

        public List<S_Vec3Geo> Points
        {
            get
            {
                return this.m_points;
            }
            set
            {
                this.m_points.Clear();
                for (int i = 0; i < value.Count; i++)
                {
                    this.m_points.Add(value[i]);
                }
            }
        }
    }
}

