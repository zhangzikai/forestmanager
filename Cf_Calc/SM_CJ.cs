namespace Cf_Calc
{
    using System;

    internal class SM_CJ : JJCJ_Render
    {
        public SM_CJ()
        {
            base._Name = "杉木";
        }

        public override double Calc(double d, double h)
        {
            return (((0.65671 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 1.769412)) * Math.Pow(h, 1.069769));
        }
    }
}

