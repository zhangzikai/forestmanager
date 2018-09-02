namespace Cartography
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class LegendService
    {
        private static string _path;

        public static void AppendLegendItem(string pTxt)
        {
            FileInfo info = new FileInfo(path);
            using (StreamWriter writer = info.AppendText())
            {
                writer.WriteLine(pTxt);
            }
        }

        public static void ChangeLegendItemOrderBottom(ILegend pLegend, List<int> pPos)
        {
            List<ILegendItem> list = new List<ILegendItem>();
            foreach (int num in pPos)
            {
                list.Add(pLegend.get_Item(num));
            }
            foreach (int num2 in pPos)
            {
                pLegend.RemoveItem(num2);
            }
            foreach (ILegendItem item in list)
            {
                pLegend.InsertItem(pLegend.ItemCount, item);
            }
        }

        public static void ChangeLegendItemOrderBottom(List<ILegendItem> pLegendItems, List<int> pPos)
        {
            List<ILegendItem> list = new List<ILegendItem>();
            foreach (int num in pPos)
            {
                list.Add(pLegendItems[num]);
            }
            foreach (int num2 in pPos)
            {
                pLegendItems.RemoveAt(num2);
            }
            foreach (ILegendItem item in list)
            {
                pLegendItems.Insert(pLegendItems.Count, item);
            }
        }

        public static void ChangeLegendItemOrderDown(ILegend pLegend, List<int> pPos)
        {
            int itemCount = pLegend.ItemCount;
            foreach (int num2 in pPos)
            {
                int index = num2;
                if ((index + 1) == itemCount)
                {
                    itemCount = index;
                }
                else
                {
                    itemCount = index + 1;
                    ILegendItem item = pLegend.get_Item(index);
                    pLegend.RemoveItem(index);
                    pLegend.InsertItem(itemCount, item);
                }
            }
        }

        public static void ChangeLegendItemOrderDown(List<ILegendItem> pLegendItems, List<int> pPos)
        {
            int count = pLegendItems.Count;
            foreach (int num2 in pPos)
            {
                int num3 = num2;
                if ((num3 + 1) == count)
                {
                    count = num3;
                }
                else
                {
                    count = num3 + 1;
                    ILegendItem item = pLegendItems[count];
                    pLegendItems[count] = pLegendItems[num3];
                    pLegendItems[num3] = item;
                }
            }
        }

        public static void ChangeLegendItemOrderTop(ILegend pLegend, List<int> pPos)
        {
            List<ILegendItem> list = new List<ILegendItem>();
            foreach (int num in pPos)
            {
                list.Add(pLegend.get_Item(num));
            }
            foreach (int num2 in pPos)
            {
                pLegend.RemoveItem(num2);
            }
            int index = 0;
            foreach (ILegendItem item in list)
            {
                pLegend.InsertItem(index, item);
                index++;
            }
        }

        public static void ChangeLegendItemOrderTop(List<ILegendItem> pLegendItems, List<int> pPos)
        {
            List<ILegendItem> list = new List<ILegendItem>();
            foreach (int num in pPos)
            {
                list.Add(pLegendItems[num]);
            }
            foreach (int num2 in pPos)
            {
                pLegendItems.RemoveAt(num2);
            }
            int index = 0;
            foreach (ILegendItem item in list)
            {
                pLegendItems.Insert(index, item);
                index++;
            }
        }

        public static void ChangeLegendItemOrderUp(ILegend pLegend, List<int> pPos)
        {
            int index = -1;
            foreach (int num2 in pPos)
            {
                int num3 = num2;
                if ((num3 - 1) == index)
                {
                    index = num3;
                }
                else
                {
                    index = num3 - 1;
                    ILegendItem item = pLegend.get_Item(num3);
                    pLegend.InsertItem(index, item);
                    pLegend.RemoveItem(num3 + 1);
                }
            }
        }

        public static void ChangeLegendItemOrderUp(List<ILegendItem> pLegendItems, List<int> pPos)
        {
            int num = -1;
            foreach (int num2 in pPos)
            {
                int num3 = num2;
                if ((num3 - 1) == num)
                {
                    num = num3;
                }
                else
                {
                    num = num3 - 1;
                    ILegendItem item = pLegendItems[num];
                    pLegendItems[num] = pLegendItems[num3];
                    pLegendItems[num3] = item;
                }
            }
        }

        public static ILegendItem CreateLegendItem(ILayer pLy, double pWidth, double pHeight, IStyleGalleryItem pItem, IScreenDisplay pDisPlay)
        {
            ILegendItem item = new HorizontalLegendItemClass();
            item.Layer = pLy;
            ILegendFormat legendFormat = new LegendFormatClass();
            if (pLy is IFeatureLayer)
            {
                IFeatureLayer layer = (IFeatureLayer) pLy;
                if (layer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint)
                {
                    legendFormat.DefaultPatchWidth = 30.0;
                    legendFormat.DefaultPatchHeight = 15.0;
                }
            }
            item.CreateGraphics(pDisPlay, legendFormat);
            item.LegendClassFormat.PatchWidth = 30.0;
            item.LegendClassFormat.PatchHeight = 15.0;
            return item;
        }

        public static List<ILegendItem> CreateLegendItemFromExist(List<ILegendItem> pOrigLegendItem, ILegendItem pTarLegendItem, IScreenDisplay pScreenDisplay, ILegendFormat pFormat)
        {
            List<ILegendItem> list = new List<ILegendItem>();
            foreach (ILegendItem item in pOrigLegendItem)
            {
                object pOverwriteObject = null;
                if ((pTarLegendItem is IHorizontalBarLegendItem) && (pTarLegendItem is IVerticalLegendItem))
                {
                    pOverwriteObject = new HorizontalBarLegendItemClass();
                }
                if ((pTarLegendItem is IHorizontalLegendItem) && !(pTarLegendItem is INestedLegendItem))
                {
                    pOverwriteObject = new HorizontalLegendItemClass();
                }
                if ((pTarLegendItem is INestedLegendItem) && (pTarLegendItem is IHorizontalLegendItem))
                {
                    pOverwriteObject = new NestedLegendItemClass();
                }
                if ((pTarLegendItem is IVerticalLegendItem) && !(pTarLegendItem is IHorizontalBarLegendItem))
                {
                    pOverwriteObject = new VerticalLegendItemClass();
                }
                IObjectCopy copy = new ObjectCopyClass();
                object pInObject = copy.Copy(pTarLegendItem);
                copy.Overwrite(pInObject, ref pOverwriteObject);
                ILegendItem item2 = (ILegendItem) pOverwriteObject;
                item2.Layer = item.Layer;
                item2.CreateGraphics(pScreenDisplay, pFormat);
                item2.Columns = item.Columns;
                item2.GroupIndex = item.GroupIndex;
                item2.NewColumn = item.NewColumn;
                item2.KeepTogether = item.KeepTogether;
                item2.HeadingSymbol = item.HeadingSymbol;
                item2.LayerNameSymbol = item.LayerNameSymbol;
                item2.LegendClassFormat = item.LegendClassFormat;
                list.Add(item2);
            }
            return list;
        }

        public static ILegendItem GetItemByIndex(int pIndex, ILegend pLegend)
        {
            return pLegend.get_Item(pIndex);
        }

        public static ILegendItem GetItemByLayerName(string pLyName, ILegend pLegend)
        {
            for (int i = 0; i < pLegend.ItemCount; i++)
            {
                ILegendItem item = pLegend.get_Item(i);
                if (item.Layer.Name == pLyName)
                {
                    return item;
                }
            }
            return null;
        }

        public static ILegendItem GetLegendItemByIndex(int pIndex, List<ILegendItem> pLegendItems)
        {
            return pLegendItems[pIndex];
        }

        public static ILegendItem GetLegendItemByLayerName(ILegendItem pLegendItem, List<ILegendItem> pLegendItems)
        {
            foreach (ILegendItem item in pLegendItems)
            {
                if (item.Layer.Name == pLegendItem.Layer.Name)
                {
                    return item;
                }
            }
            return null;
        }

        public static ILegendItem GetLegendItemByLayerName(string pLyName, List<ILegendItem> pLegendItems)
        {
            foreach (ILegendItem item in pLegendItems)
            {
                if (pLyName == item.Layer.Name)
                {
                    return item;
                }
            }
            return null;
        }

        public static void GetPath()
        {
            _path = AppDomain.CurrentDomain.BaseDirectory;
            _path = _path.Remove(path.LastIndexOf(@"\"));
            _path = _path.Remove(path.LastIndexOf(@"\"));
            _path = _path.Remove(path.LastIndexOf(@"\") + 1);
            _path = _path + @"FormMain\Graphics";
            new DirectoryInfo(_path).Create();
            _path = _path + @"\LegendItemPatch.txt";
        }

        public static Dictionary<string, string> ReadLegendItemPatch()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            using (StreamReader reader = File.OpenText(path))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(new char[] { ',' });
                    dictionary.Add(strArray[0], strArray[1]);
                }
            }
            return dictionary;
        }

        public static string ReadLegendItemPatch(string pLyName)
        {
            using (StreamReader reader = File.OpenText(path))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(new char[] { ',' });
                    if (strArray[0] == pLyName)
                    {
                        return strArray[1];
                    }
                }
            }
            return null;
        }

        public static void ReMoveItemByIndex(int pIndex, ILegend pLegend)
        {
            pLegend.RemoveItem(pIndex);
        }

        public static int ReMoveItemByLayerName(string pLyName, ILegend pLegend)
        {
            for (int i = 0; i < pLegend.ItemCount; i++)
            {
                if (pLegend.get_Item(i).Layer.Name == pLyName)
                {
                    pLegend.RemoveItem(i);
                    return i;
                }
            }
            return -1;
        }

        public static bool RemoveLegendItem(ILegendItem pLegendItem, List<ILegendItem> pLegendItems)
        {
            foreach (ILegendItem item in pLegendItems)
            {
                if (item.Layer.Name == pLegendItem.Layer.Name)
                {
                    return false;
                }
            }
            return true;
        }

        public static void RemoveLegendItemByIndex(int pIndex, List<ILegendItem> pLegendItems)
        {
            pLegendItems.RemoveAt(pIndex);
        }

        public static int RemoveLegendItemByLyName(string pLyName, List<ILegendItem> pLegendItems)
        {
            int index = -1;
            for (int i = 0; i < pLegendItems.Count; i++)
            {
                if (pLegendItems[i].Layer.Name == pLyName)
                {
                    index = i;
                    break;
                }
            }
            pLegendItems.RemoveAt(index);
            return index;
        }

        public static void WriteLegendItem(Dictionary<string, string> pLyItems)
        {
            string str = "";
            foreach (KeyValuePair<string, string> pair in pLyItems)
            {
                string str2 = str;
                str = str2 + pair.Key + "," + pair.Value + Environment.NewLine;
            }
            FileInfo info = new FileInfo(path);
            using (StreamWriter writer = info.CreateText())
            {
                writer.Write(str);
            }
        }

        public static void WriteLegendItem(string pTxt)
        {
            FileInfo info = new FileInfo(path);
            using (StreamWriter writer = info.CreateText())
            {
                writer.Write(pTxt);
            }
        }

        public static string path
        {
            get
            {
                if (_path == null)
                {
                    GetPath();
                }
                return _path;
            }
        }
    }
}

