namespace LDZY_ZTZZ
{
    using System;

    public class JSXBXJL
    {
        public double GetXBXJL(string di_lei, string you_shi_sz, double pingjun_sg, double pingjun_xj, double pingjun_dm, double mianji)
        {
            double num = 0.0;
            int digits = 1;
            if (((di_lei.Trim() != "111") && (di_lei.Trim() != "112")) && (di_lei.Trim() != "200"))
            {
                return num;
            }
            if (((you_shi_sz.Trim().Length <= 0) || (pingjun_sg <= 0.0)) || ((pingjun_dm <= 0.0) || (pingjun_xj < 5.0)))
            {
                return num;
            }
            double num3 = 0.0;
            if (((((Convert.ToInt16(you_shi_sz) / 10) != 11) && ((Convert.ToInt16(you_shi_sz) / 10) != 13)) && ((Convert.ToInt16(you_shi_sz) / 10) != 15)) && ((Convert.ToInt16(you_shi_sz) / 10) != 0x10))
            {
                if ((Convert.ToInt16(you_shi_sz) / 10) == 12)
                {
                    num3 = Math.Round((double) (((0.45225 + (1.31334 / (pingjun_sg + 2.0))) * pingjun_sg) * pingjun_dm), digits, MidpointRounding.AwayFromZero);
                }
                else if ((Convert.ToInt16(you_shi_sz) / 10) == 14)
                {
                    num3 = Math.Round((double) (((0.43853 + (1.15672 / (pingjun_sg - 1.0))) * pingjun_sg) * pingjun_dm), digits, MidpointRounding.AwayFromZero);
                }
                else if ((((Convert.ToInt16(you_shi_sz) >= 210) && (Convert.ToInt16(you_shi_sz) < 220)) || ((Convert.ToInt16(you_shi_sz) >= 240) && (Convert.ToInt16(you_shi_sz) < 280))) || (((Convert.ToInt16(you_shi_sz) >= 330) && (Convert.ToInt16(you_shi_sz) < 400)) || ((Convert.ToInt16(you_shi_sz) >= 600) && (Convert.ToInt16(you_shi_sz) < 800))))
                {
                    num3 = Math.Round((double) (((0.40489 + (3.37866 / (pingjun_sg + 20.0))) * pingjun_sg) * pingjun_dm), digits, MidpointRounding.AwayFromZero);
                }
                else if (((Convert.ToInt16(you_shi_sz) / 10) != 0x16) && ((Convert.ToInt16(you_shi_sz) / 10) != 0x17))
                {
                    if ((Convert.ToInt16(you_shi_sz) >= 290) && (Convert.ToInt16(you_shi_sz) < 310))
                    {
                        double num5 = 0.97670866;
                        double y = -0.068428604;
                        double num7 = -0.18596012;
                        double num8 = (num5 * Math.Pow(pingjun_xj, y)) * Math.Pow(pingjun_sg, num7);
                        double num9 = (pingjun_dm * pingjun_sg) * num8;
                        num3 = Math.Round(num9, digits, MidpointRounding.AwayFromZero);
                    }
                    else if ((((Convert.ToInt16(you_shi_sz) / 10) != 0x1c) && ((Convert.ToInt16(you_shi_sz) / 10) != 0x1f)) && ((Convert.ToInt16(you_shi_sz) / 10) != 0x20))
                    {
                        num3 = 0.0;
                    }
                    else
                    {
                        num3 = Math.Round((double) (((0.3797 + (1.00761 / pingjun_sg)) * pingjun_sg) * pingjun_dm), digits, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    num3 = Math.Round((double) ((pingjun_dm * 0.386) * (pingjun_sg + 3.0)), digits, MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                num3 = Math.Round((double) (((0.36445 + (1.94272 / (pingjun_sg + 2.0))) * pingjun_sg) * pingjun_dm), digits, MidpointRounding.AwayFromZero);
            }
            double num4 = num3 * mianji;
            return Convert.ToDouble(num4.ToString("f1"));
        }
    }
}

