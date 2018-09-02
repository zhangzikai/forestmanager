namespace Cf_Calc
{
    using System;

    internal class JJCJ_Render
    {
        protected string _Name = "";

        public virtual double Calc(double d, double h)
        {
            return 0.0;
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }
    }
}

