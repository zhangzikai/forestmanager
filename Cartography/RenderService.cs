namespace Cartography
{
    using Cartography.Render;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using System;
    using System.Collections.Generic;

    internal class RenderService
    {
        public static List<ISymbol> GetFeatureLayerSymbol(ILayer pLayer)
        {
            List<ISymbol> list = new List<ISymbol>();
            IFeatureRenderer renderer = null;
            if (!(pLayer is IFeatureLayer))
            {
                return list;
            }
            IGeoFeatureLayer layer = (IGeoFeatureLayer) pLayer;
            renderer = layer.Renderer;
            if (!(renderer is IUniqueValueRenderer))
            {
                if (renderer is ISimpleRenderer)
                {
                    ISimpleRenderer renderer3 = (ISimpleRenderer) renderer;
                    list.Add(renderer3.Symbol);
                }
                return list;
            }
            IUniqueValueRenderer renderer2 = (IUniqueValueRenderer) renderer;
            if (renderer2.ValueCount == 0)
            {
                list.Add(renderer2.DefaultSymbol);
                return list;
            }
            if (renderer2.UseDefaultSymbol)
            {
                list.Add(renderer2.DefaultSymbol);
            }
            List<string> list2 = new List<string>();
            int index = 0;
        Label_006A:
            if (index >= renderer2.ValueCount)
            {
                return list;
            }
            ISymbol item = null;
            string str = renderer2.get_Value(index);
            try
            {
                string str2 = renderer2.get_ReferenceValue(str);
                if (list2.Contains(str2))
                {
                    goto Label_00CE;
                }
                list2.Add(str2);
                item = renderer2.get_Symbol(str2);
            }
            catch
            {
                item = renderer2.get_Symbol(str);
                list2.Add(str);
            }
            if (item != null)
            {
                list.Add(item);
            }
        Label_00CE:
            index++;
            goto Label_006A;
        }

        public static List<ISymbol> GetLegendGroupSymbol(ILegendGroup pGroup)
        {
            List<ISymbol> list = new List<ISymbol>();
            for (int i = 0; i < pGroup.ClassCount; i++)
            {
                ILegendClass class2 = pGroup.get_Class(i);
                list.Add(class2.Symbol);
            }
            return list;
        }

        public static List<ISymbol> GetRasterLayerSymbol(IRasterLayer pRasterLy)
        {
            return null;
        }

        public static List<string> GetRefernceValue(IUniqueValueRenderer pUniqueValueRender)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < pUniqueValueRender.ValueCount; i++)
            {
                string str = pUniqueValueRender.get_Value(i);
                string item = "";
                try
                {
                    item = pUniqueValueRender.get_ReferenceValue(str);
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
                catch
                {
                    list.Add(str);
                }
            }
            return list;
        }

        public static ISymbol GetTopoLayerSymbol(ILayer pLayer, esriTopologyRenderer pRender)
        {
            IFeatureRenderer renderer = null;
            ISymbol symbol = null;
            if (pLayer is ITopologyLayer)
            {
                renderer = (pLayer as ITopologyLayer).get_Renderer(pRender);
                if (renderer is ISimpleRenderer)
                {
                    ISimpleRenderer renderer2 = (ISimpleRenderer) renderer;
                    symbol = renderer2.Symbol;
                }
            }
            return symbol;
        }

        public static bool SetLegendGroupSymbol(ILayer pLayer, int pIndex, ITOCControl pTocControl, ILegendGroup pGroup)
        {
            DevSymbolSelector selector = new DevSymbolSelector();
            IFeatureLayer layer = null;
            List<ISymbol> legendGroupSymbol = GetLegendGroupSymbol(pGroup);
            IStyleGalleryItem pItem = null;
            layer = (IFeatureLayer) pLayer;
            pItem = selector.GetItem(layer.FeatureClass.ShapeType, legendGroupSymbol, pIndex);
            selector.Dispose();
            if (pItem == null)
            {
                return false;
            }
            SetLegendGroupSymbol(pItem, pGroup, pIndex, pTocControl);
            return true;
        }

        public static void SetLegendGroupSymbol(IStyleGalleryItem pItem, ILegendGroup pGroup, int pIndex, ITOCControl pTocControl)
        {
            ILegendClass class2 = pGroup.get_Class(pIndex);
            ISymbol item = pItem.Item as ISymbol;
            if (item == null)
            {
                throw new Exception("符号库有问题");
            }
            class2.Symbol = item;
        }

        public static void SetTopoRender(IStyleGalleryItem pItem, ILayer pLayer, esriTopologyRenderer pRender, ITOCControl pTocControl)
        {
            IFeatureRenderer renderer = null;
            if (pLayer is ITopologyLayer)
            {
                renderer = ((ITopologyLayer) pLayer).get_Renderer(pRender);
            }
            if (renderer is ISimpleRenderer)
            {
                ISimpleRenderer renderer2 = (ISimpleRenderer) renderer;
                renderer2.Symbol = (ISymbol) pItem.Item;
            }
        }

        public static void SetTopoSymbol(ILayer pLayer, IMap pMap, esriTopologyRenderer pRender, ITOCControl pTocControl)
        {
            DevSymbolSelector selector = new DevSymbolSelector();
            ISymbol topoLayerSymbol = GetTopoLayerSymbol(pLayer, pRender);
            IStyleGalleryItem pItem = null;
            pItem = selector.GetItem(topoLayerSymbol);
            selector.Dispose();
            if (pItem != null)
            {
                SetTopoRender(pItem, pLayer, pRender, pTocControl);
                IActiveView view = (IActiveView) pMap;
                view.PartialRefresh(esriViewDrawPhase.esriViewGeography, pLayer, view.Extent);
            }
        }
    }
}

