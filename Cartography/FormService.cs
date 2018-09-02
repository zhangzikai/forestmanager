namespace Cartography
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.esriSystem;
    using System;
    using System.Drawing;

    public class FormService
    {
        internal static esriPageFormID GetFormIdByName(string pName)
        {
            switch (pName)
            {
                case "A0":
                    return esriPageFormID.esriPageFormA0;

                case "A1":
                    return esriPageFormID.esriPageFormA1;

                case "A2":
                    return esriPageFormID.esriPageFormA2;

                case "A3":
                    return esriPageFormID.esriPageFormA3;

                case "A4":
                    return esriPageFormID.esriPageFormA4;

                case "A5":
                    return esriPageFormID.esriPageFormA5;

                case "C":
                    return esriPageFormID.esriPageFormC;

                case "自定义":
                    return esriPageFormID.esriPageFormCUSTOM;

                case "D":
                    return esriPageFormID.esriPageFormD;

                case "E":
                    return esriPageFormID.esriPageFormE;

                case "Legal":
                    return esriPageFormID.esriPageFormLegal;

                case "Letter":
                    return esriPageFormID.esriPageFormLetter;

                case "":
                    return esriPageFormID.esriPageFormSameAsPrinter;

                case "Tabloid":
                    return esriPageFormID.esriPageFormTabloid;
            }
            return esriPageFormID.esriPageFormCUSTOM;
        }

        internal static string GetFormStrByEnum(esriPageFormID pFormId)
        {
            switch (pFormId)
            {
                case esriPageFormID.esriPageFormLetter:
                    return "Letter";

                case esriPageFormID.esriPageFormLegal:
                    return "Legal";

                case esriPageFormID.esriPageFormTabloid:
                    return "Tabloid";

                case esriPageFormID.esriPageFormC:
                    return "C";

                case esriPageFormID.esriPageFormD:
                    return "D";

                case esriPageFormID.esriPageFormE:
                    return "E";

                case esriPageFormID.esriPageFormA5:
                    return "A5";

                case esriPageFormID.esriPageFormA4:
                    return "A4";

                case esriPageFormID.esriPageFormA3:
                    return "A3";

                case esriPageFormID.esriPageFormA2:
                    return "A2";

                case esriPageFormID.esriPageFormA1:
                    return "A1";

                case esriPageFormID.esriPageFormA0:
                    return "A0";

                case esriPageFormID.esriPageFormCUSTOM:
                    return "自定义";
            }
            return "自定义";
        }

        internal static SizeF GetSizeByFormID(esriPageFormID pID, esriUnits pUnitOut)
        {
            IUnitConverter converter = new UnitConverterClass();
            double dValue = -1.0;
            double num2 = -1.0;
            esriUnits esriUnknownUnits = esriUnits.esriUnknownUnits;
            SizeF ef = new SizeF();
            switch (pID)
            {
                case esriPageFormID.esriPageFormLetter:
                    dValue = 8.5;
                    num2 = 11.0;
                    esriUnknownUnits = esriUnits.esriInches;
                    break;

                case esriPageFormID.esriPageFormLegal:
                    dValue = 8.5;
                    num2 = 14.0;
                    esriUnknownUnits = esriUnits.esriInches;
                    break;

                case esriPageFormID.esriPageFormTabloid:
                    dValue = 11.0;
                    num2 = 17.0;
                    esriUnknownUnits = esriUnits.esriInches;
                    break;

                case esriPageFormID.esriPageFormC:
                    dValue = 17.0;
                    num2 = 22.0;
                    esriUnknownUnits = esriUnits.esriInches;
                    break;

                case esriPageFormID.esriPageFormD:
                    dValue = 22.0;
                    num2 = 34.0;
                    esriUnknownUnits = esriUnits.esriInches;
                    break;

                case esriPageFormID.esriPageFormE:
                    dValue = 34.0;
                    num2 = 44.0;
                    esriUnknownUnits = esriUnits.esriInches;
                    break;

                case esriPageFormID.esriPageFormA5:
                    dValue = 148.0;
                    num2 = 210.0;
                    esriUnknownUnits = esriUnits.esriMillimeters;
                    break;

                case esriPageFormID.esriPageFormA4:
                    dValue = 210.0;
                    num2 = 297.0;
                    esriUnknownUnits = esriUnits.esriMillimeters;
                    break;

                case esriPageFormID.esriPageFormA3:
                    dValue = 297.0;
                    num2 = 420.0;
                    esriUnknownUnits = esriUnits.esriMillimeters;
                    break;

                case esriPageFormID.esriPageFormA2:
                    dValue = 420.0;
                    num2 = 594.0;
                    esriUnknownUnits = esriUnits.esriMillimeters;
                    break;

                case esriPageFormID.esriPageFormA1:
                    dValue = 594.0;
                    num2 = 841.0;
                    esriUnknownUnits = esriUnits.esriMillimeters;
                    break;

                case esriPageFormID.esriPageFormA0:
                    dValue = 841.0;
                    num2 = 1189.0;
                    esriUnknownUnits = esriUnits.esriMillimeters;
                    break;

                default:
                    dValue = -1.0;
                    num2 = -1.0;
                    break;
            }
            ef.Width = (float) converter.ConvertUnits(dValue, esriUnknownUnits, pUnitOut);
            ef.Height = (float) converter.ConvertUnits(num2, esriUnknownUnits, pUnitOut);
            return ef;
        }
    }
}

