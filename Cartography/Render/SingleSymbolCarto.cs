namespace Cartography.Render
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using System;

    internal class SingleSymbolCarto
    {
        public static void SetSimpleRenderSymbol(IFeatureLayer pFeatureLayer, ISymbol pSymbol)
        {
            IGeoFeatureLayer layer = pFeatureLayer as IGeoFeatureLayer;
            if (layer.Renderer is ISimpleRenderer)
            {
                ISimpleRenderer renderer = layer.Renderer as ISimpleRenderer;
                renderer.Symbol = pSymbol;
            }
            else
            {
                ISimpleRenderer renderer2 = new SimpleRendererClass();
                renderer2.Symbol = pSymbol;
                layer.Renderer = renderer2 as IFeatureRenderer;
            }
        }
    }
}

