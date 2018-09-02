namespace Cf_Calc
{
    using System;

    internal class AS2_CJ : JJCJ_Render
    {
        public AS2_CJ()
        {
            base._Name = "桉树2";
        }

        public override double Calc(double d, double h)
        {
            return (((((0.0434785 - ((6.75245 * Math.Pow(10.0, -3.0)) * d)) + ((2.73652 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 2.0))) + (((5.02044 * Math.Pow(10.0, -4.0)) * d) * h)) + (((1.54609 * Math.Pow(10.0, -5.0)) * Math.Pow(d, 2.0)) * h)) - ((3.35291 * Math.Pow(10.0, -3.0)) * h));
        }
    }
}

