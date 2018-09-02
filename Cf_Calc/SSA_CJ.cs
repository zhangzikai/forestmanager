namespace Cf_Calc
{
    using System;

    internal class SSA_CJ : JJCJ_Render
    {
        public SSA_CJ()
        {
            base._Name = "速生桉";
        }

        public override double Calc(double d, double h)
        {
            return (((1.09154145 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 1.8789237 - ((5.69185503 * Math.Pow(10.0, -3.0)) * (d + h)))) * Math.Pow(h, 0.65259805 + ((7.84753507 * Math.Pow(10.0, -3.0)) * (d + h))));
        }
    }
}

