namespace Print
{
    using ESRI.ArcGIS.esriSystem;
    using System;

    public class UnitService
    {
        internal static string GetCN(esriUnits pUnit)
        {
            string str = string.Empty;
            switch (pUnit)
            {
                case esriUnits.esriUnknownUnits:
                    return "未知";

                case esriUnits.esriInches:
                    return "英寸";

                case esriUnits.esriPoints:
                    return "点";

                case esriUnits.esriFeet:
                    return "英尺";

                case esriUnits.esriYards:
                    return "码";

                case esriUnits.esriMiles:
                    return "英里";

                case esriUnits.esriNauticalMiles:
                    return "海里";

                case esriUnits.esriMillimeters:
                    return "毫米";

                case esriUnits.esriCentimeters:
                    return "厘米";

                case esriUnits.esriMeters:
                    return "米";

                case esriUnits.esriKilometers:
                    return "千米";

                case esriUnits.esriDecimalDegrees:
                    return "十进制度";

                case esriUnits.esriDecimeters:
                    return "分米";

                case esriUnits.esriUnitsLast:
                    return "内部使用单位";
            }
            return str;
        }
    }
}

