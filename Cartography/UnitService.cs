namespace Cartography
{
    using ESRI.ArcGIS.esriSystem;
    using System;

    internal class UnitService
    {
        public static double ConvertUnit(double pValue, esriUnits pSunit, esriUnits pTUnit)
        {
            double num = 0.0;
            switch (pSunit)
            {
                case esriUnits.esriInches:
                    switch (pTUnit)
                    {
                        case esriUnits.esriPoints:
                            num = pValue * 72.0;
                            goto Label_0210;

                        case esriUnits.esriCentimeters:
                            num = pValue * 2.54;
                            goto Label_0210;

                        case esriUnits.esriMeters:
                            num = pValue * 0.0254;
                            goto Label_0210;

                        case esriUnits.esriKilometers:
                            num = pValue * 2.54E-05;
                            goto Label_0210;

                        case esriUnits.esriDecimeters:
                            num = pValue * 0.254;
                            goto Label_0210;
                    }
                    break;

                case esriUnits.esriMillimeters:
                    switch (pTUnit)
                    {
                        case esriUnits.esriInches:
                            num = 0.03937 * pValue;
                            goto Label_0210;

                        case esriUnits.esriMillimeters:
                            num = pValue;
                            goto Label_0210;

                        case esriUnits.esriCentimeters:
                            num = pValue * 0.1;
                            goto Label_0210;

                        case esriUnits.esriMeters:
                            num = pValue * 0.001;
                            goto Label_0210;
                    }
                    break;

                case esriUnits.esriCentimeters:
                    switch (pTUnit)
                    {
                        case esriUnits.esriInches:
                            num = 0.3937 * pValue;
                            goto Label_0210;

                        case esriUnits.esriPoints:
                            num = pValue / 0.035;
                            goto Label_0210;

                        case esriUnits.esriMiles:
                            num = pValue / 160934.40058;
                            goto Label_0210;

                        case esriUnits.esriMillimeters:
                            num = pValue * 10.0;
                            goto Label_0210;

                        case esriUnits.esriCentimeters:
                            num = pValue;
                            goto Label_0210;

                        case esriUnits.esriMeters:
                            num = pValue / 100.0;
                            goto Label_0210;

                        case esriUnits.esriKilometers:
                            num = pValue / 100000.0;
                            goto Label_0210;

                        case esriUnits.esriDecimeters:
                            num = 0.1 * pValue;
                            goto Label_0210;
                    }
                    break;
            }
        Label_0210:
            return Math.Round(num, 2);
        }

        public static esriUnits GetUnitFromChineseUnitESRI(string pChineseUnit)
        {
            switch (pChineseUnit)
            {
                case "厘米":
                    return esriUnits.esriCentimeters;

                case "十进制度数":
                    return esriUnits.esriDecimalDegrees;

                case "分米":
                    return esriUnits.esriDecimeters;

                case "英尺":
                    return esriUnits.esriFeet;

                case "英寸":
                    return esriUnits.esriInches;

                case "千米":
                    return esriUnits.esriKilometers;

                case "米":
                    return esriUnits.esriMeters;

                case "英里":
                    return esriUnits.esriMiles;

                case "毫米":
                    return esriUnits.esriMillimeters;

                case "海里":
                    return esriUnits.esriNauticalMiles;

                case "点":
                    return esriUnits.esriPoints;

                case "内部使用单位":
                    return esriUnits.esriUnitsLast;

                case "未知":
                    return esriUnits.esriUnknownUnits;

                case "码":
                    return esriUnits.esriYards;
            }
            return esriUnits.esriUnknownUnits;
        }

        public static string GetUnitFromESRIUnit(esriUnits pEsriUnits)
        {
            switch (pEsriUnits)
            {
                case esriUnits.esriUnknownUnits:
                    return "UnkownUnits";

                case esriUnits.esriInches:
                    return "Inches";

                case esriUnits.esriPoints:
                    return "Points";

                case esriUnits.esriFeet:
                    return "Feet";

                case esriUnits.esriYards:
                    return "Yards";

                case esriUnits.esriMiles:
                    return "Miles";

                case esriUnits.esriNauticalMiles:
                    return "NauticalMiles";

                case esriUnits.esriMillimeters:
                    return "Millimeters";

                case esriUnits.esriCentimeters:
                    return "Centimeters";

                case esriUnits.esriMeters:
                    return "Meters";

                case esriUnits.esriKilometers:
                    return "Kilometers";

                case esriUnits.esriDecimalDegrees:
                    return "DecimalDegrees";

                case esriUnits.esriDecimeters:
                    return "Decimeters";

                case esriUnits.esriUnitsLast:
                    return "UnitsLast";
            }
            return "";
        }

        public static string GetUnitFromESRIUnitAbb(esriUnits pEsriUnits)
        {
            switch (pEsriUnits)
            {
                case esriUnits.esriUnknownUnits:
                    return "uu";

                case esriUnits.esriInches:
                    return "in";

                case esriUnits.esriPoints:
                    return "p";

                case esriUnits.esriFeet:
                    return "Feet";

                case esriUnits.esriYards:
                    return "y";

                case esriUnits.esriMiles:
                    return "mi";

                case esriUnits.esriNauticalMiles:
                    return "nm";

                case esriUnits.esriMillimeters:
                    return "mm";

                case esriUnits.esriCentimeters:
                    return "cm";

                case esriUnits.esriMeters:
                    return "m";

                case esriUnits.esriKilometers:
                    return "km";

                case esriUnits.esriDecimalDegrees:
                    return "dd";

                case esriUnits.esriDecimeters:
                    return "dm";

                case esriUnits.esriUnitsLast:
                    return "ul";
            }
            return "";
        }

        public static string GetUnitFromESRIUnitChinese(esriUnits pEsriUnits)
        {
            switch (pEsriUnits)
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
                    return "十进制度数";

                case esriUnits.esriDecimeters:
                    return "分米";

                case esriUnits.esriUnitsLast:
                    return "内部使用单位";
            }
            return "未知";
        }
    }
}

