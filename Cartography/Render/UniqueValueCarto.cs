namespace Cartography.Render
{
    using Cartography;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    internal class UniqueValueCarto
    {
        public static ISymbol CreateSymbol(esriGeometryType pType, Color pColor)
        {
            ISymbol symbol = null;
            switch (pType)
            {
                case esriGeometryType.esriGeometryPoint:
                {
                    ISimpleMarkerSymbol symbol2 = new SimpleMarkerSymbolClass();
                    symbol2.Color = ColorService.NetColorToEsriColor(pColor);
                    return (symbol2 as ISymbol);
                }
                case esriGeometryType.esriGeometryMultipoint:
                    return symbol;

                case esriGeometryType.esriGeometryPolyline:
                {
                    ISimpleLineSymbol symbol4 = new SimpleLineSymbolClass();
                    symbol4.Color = ColorService.NetColorToEsriColor(pColor);
                    return (symbol4 as ISymbol);
                }
                case esriGeometryType.esriGeometryPolygon:
                {
                    ISimpleFillSymbol symbol3 = new SimpleFillSymbolClass();
                    symbol3.Color = ColorService.NetColorToEsriColor(pColor);
                    return (symbol3 as ISymbol);
                }
            }
            return symbol;
        }

        public static string GetCartoFieldAliasName(IFeatureRenderer pRender)
        {
            IUniqueValueRenderer renderer = pRender as IUniqueValueRenderer;
            if ((renderer != null) && (renderer.FieldCount > 0))
            {
                return renderer.get_Field(0);
            }
            return null;
        }

        public static void Recovery(ref IFeatureRenderer pRender, string[] pFields)
        {
            IUniqueValueRenderer renderer = pRender as IUniqueValueRenderer;
            if (renderer != null)
            {
                for (int i = 0; i < pFields.Length; i++)
                {
                    renderer.set_Field(i, pFields[i]);
                }
            }
        }

        public static ISymbol SetSymbolByColorRamp(esriGeometryType pType, IColor pColor)
        {
            ISymbol symbol = null;
            switch (pType)
            {
                case esriGeometryType.esriGeometryPoint:
                    symbol = new SimpleMarkerSymbolClass();
                    ((ISimpleMarkerSymbol) symbol).Color = pColor;
                    return symbol;

                case esriGeometryType.esriGeometryMultipoint:
                    return symbol;

                case esriGeometryType.esriGeometryPolyline:
                    symbol = new SimpleLineSymbolClass();
                    ((ISimpleLineSymbol) symbol).Color = pColor;
                    return symbol;

                case esriGeometryType.esriGeometryPolygon:
                    symbol = new SimpleFillSymbolClass();
                    ((IFillSymbol) symbol).Color = pColor;
                    return symbol;
            }
            return symbol;
        }

        public static void SortMany(IUniqueValueRenderer pRender, string pHeadingUp, string pHeadingDown)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Dictionary<string, List<ValueClass>> dictionary2 = new Dictionary<string, List<ValueClass>>();
            while (true)
            {
                if (pRender.ValueCount <= 0)
                {
                    break;
                }
                string str = pRender.get_Value(0);
                string key = "";
                try
                {
                    key = pRender.get_ReferenceValue(str);
                    if (!dictionary2.ContainsKey(key))
                    {
                        string str3 = pRender.get_Heading(key);
                        dictionary.Add(str3, key);
                        List<ValueClass> list = new List<ValueClass>();
                        list.Add(new ValueClass(str, pRender.get_Heading(str), pRender.get_Label(str), pRender.get_Symbol(str)));
                        dictionary2.Add(key, list);
                    }
                    else
                    {
                        dictionary2[key].Add(new ValueClass(str, null, null, null));
                    }
                }
                catch
                {
                    if (!dictionary2.ContainsKey(str))
                    {
                        string str4 = pRender.get_Heading(str);
                        dictionary.Add(str4, str);
                        List<ValueClass> list2 = new List<ValueClass>();
                        list2.Add(new ValueClass(str, pRender.get_Heading(str), pRender.get_Label(str), pRender.get_Symbol(str)));
                        dictionary2.Add(str, list2);
                    }
                    else
                    {
                        dictionary2[str].Add(new ValueClass(str, null, null, null));
                    }
                }
                pRender.RemoveValue(str);
            }
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                if (pair.Key.Equals(pHeadingDown))
                {
                    List<ValueClass> list3 = dictionary2[dictionary[pHeadingDown]];
                    ValueClass class2 = list3[0];
                    pRender.AddValue(class2.Value, class2.Heading, class2.Symbol);
                    pRender.set_Label(class2.Value, class2.Label);
                    for (int i = 1; i < list3.Count; i++)
                    {
                        ValueClass class3 = list3[i];
                        pRender.AddReferenceValue(class3.Value, class2.Value);
                    }
                }
                else if (pair.Key.Equals(pHeadingUp))
                {
                    List<ValueClass> list4 = dictionary2[dictionary[pHeadingUp]];
                    ValueClass class4 = list4[0];
                    pRender.AddValue(class4.Value, class4.Heading, class4.Symbol);
                    pRender.set_Label(class4.Value, class4.Label);
                    for (int j = 1; j < list4.Count; j++)
                    {
                        ValueClass class5 = list4[j];
                        pRender.AddReferenceValue(class5.Value, class4.Value);
                    }
                }
                else
                {
                    List<ValueClass> list5 = dictionary2[pair.Value];
                    ValueClass class6 = list5[0];
                    pRender.AddValue(class6.Value, class6.Heading, class6.Symbol);
                    pRender.set_Label(class6.Value, class6.Label);
                    for (int k = 1; k < list5.Count; k++)
                    {
                        ValueClass class7 = list5[k];
                        pRender.AddReferenceValue(class7.Value, class6.Value);
                    }
                }
            }
        }

        public static void SortOne(IUniqueValueRenderer pRender, string pValueUp, string pValueDown)
        {
            Dictionary<string, List<ValueClass>> dictionary = new Dictionary<string, List<ValueClass>>();
            while (true)
            {
                if (pRender.ValueCount <= 0)
                {
                    break;
                }
                string str = pRender.get_Value(0);
                string key = "";
                try
                {
                    key = pRender.get_ReferenceValue(str);
                    if (!dictionary.ContainsKey(key))
                    {
                        List<ValueClass> list = new List<ValueClass>();
                        list.Add(new ValueClass(str, pRender.get_Heading(str), pRender.get_Label(str), pRender.get_Symbol(str)));
                        dictionary.Add(key, list);
                    }
                    else
                    {
                        dictionary[key].Add(new ValueClass(str, null, null, null));
                    }
                }
                catch
                {
                    if (!dictionary.ContainsKey(str))
                    {
                        List<ValueClass> list2 = new List<ValueClass>();
                        list2.Add(new ValueClass(str, pRender.get_Heading(str), pRender.get_Label(str), pRender.get_Symbol(str)));
                        dictionary.Add(str, list2);
                    }
                    else
                    {
                        dictionary[str].Add(new ValueClass(str, null, null, null));
                    }
                }
                pRender.RemoveValue(str);
            }
            foreach (KeyValuePair<string, List<ValueClass>> pair in dictionary)
            {
                if (pair.Key.Equals(pValueDown))
                {
                    List<ValueClass> list3 = dictionary[pValueUp];
                    ValueClass class2 = list3[0];
                    pRender.AddValue(class2.Value, class2.Heading, class2.Symbol);
                    pRender.set_Label(class2.Value, class2.Label);
                    for (int i = 1; i < list3.Count; i++)
                    {
                        ValueClass class3 = list3[i];
                        pRender.AddReferenceValue(class3.Value, class2.Value);
                    }
                }
                else if (pair.Key.Equals(pValueUp))
                {
                    List<ValueClass> list4 = dictionary[pValueDown];
                    ValueClass class4 = list4[0];
                    pRender.AddValue(class4.Value, class4.Heading, class4.Symbol);
                    pRender.set_Label(class4.Value, class4.Label);
                    for (int j = 1; j < list4.Count; j++)
                    {
                        ValueClass class5 = list4[j];
                        pRender.AddReferenceValue(class5.Value, class4.Value);
                    }
                }
                else
                {
                    List<ValueClass> list5 = pair.Value;
                    ValueClass class6 = list5[0];
                    pRender.AddValue(class6.Value, class6.Heading, class6.Symbol);
                    pRender.set_Label(class6.Value, class6.Label);
                    for (int k = 1; k < list5.Count; k++)
                    {
                        ValueClass class7 = list5[k];
                        pRender.AddReferenceValue(class7.Value, class6.Value);
                    }
                }
            }
        }
    }
}

