namespace Cf_Calc
{
    using System;

    internal class YNS_CJ : JJCJ_Render
    {
        public YNS_CJ()
        {
            base._Name = "云南松";
        }

        public override double Calc(double d, double h)
        {
            return (((0.5044 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 1.943725)) * Math.Pow(h, 0.977397));
        }
    }
}

