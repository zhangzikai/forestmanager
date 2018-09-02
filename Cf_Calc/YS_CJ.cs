namespace Cf_Calc
{
    using System;

    internal class YS_CJ : JJCJ_Render
    {
        public YS_CJ()
        {
            base._Name = "栎类";
        }

        public override double Calc(double d, double h)
        {
            return (((0.667054 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 1.8479545)) * Math.Pow(h, 0.96657509));
        }
    }
}

