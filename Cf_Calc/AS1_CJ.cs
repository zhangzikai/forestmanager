namespace Cf_Calc
{
    using System;

    internal class AS1_CJ : JJCJ_Render
    {
        public AS1_CJ()
        {
            base._Name = "桉树1";
        }

        public override double Calc(double d, double h)
        {
            return (((((1.26803 * Math.Pow(10.0, -4.0)) * Math.Pow(d, 2.00696)) * Math.Pow(Math.Pow(d, Math.Log10(d)), -0.02875)) * Math.Pow(h, 0.171793)) * Math.Pow(Math.Pow(h, Math.Log10(h)), 0.318743));
        }
    }
}

