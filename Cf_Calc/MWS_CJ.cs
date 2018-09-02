namespace Cf_Calc
{
    using System;

    internal class MWS_CJ : JJCJ_Render
    {
        public MWS_CJ()
        {
            base._Name = "马尾松";
        }

        public override double Calc(double d, double h)
        {
            return (((0.714265437 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 1.867008)) * Math.Pow(h, 0.9014632));
        }
    }
}

