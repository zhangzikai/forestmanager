namespace Cf_Calc
{
    using System;

    internal class KYS_CJ : JJCJ_Render
    {
        public KYS_CJ()
        {
            base._Name = "阔叶树";
        }

        public override double Calc(double d, double h)
        {
            return (((0.667054 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 1.8479545)) * Math.Pow(h, 0.96657509));
        }
    }
}

