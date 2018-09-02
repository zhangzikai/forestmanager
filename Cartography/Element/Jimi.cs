namespace Cartography.Element
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using stdole;
    using System;
    using System.Drawing;
    using Utilities;

    public class Jimi
    {
        private string _layerName;

        public void AddText(IActiveView pView)
        {
            ITextElement element = new TextElementClass();
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("DXTC");
            if (string.IsNullOrEmpty(configValue))
            {
                configValue = "秘密";
            }
            element.Text = configValue;
            IFormattedTextSymbol defaultTextSymbol = this.GetDefaultTextSymbol() as IFormattedTextSymbol;
            element.Symbol = defaultTextSymbol;
            IElement element2 = element as IElement;
            IPoint point = new PointClass();
            point.X = 1.0;
            point.Y = 1.0;
            element2.Geometry = point;
            pView.GraphicsContainer.AddElement(element2, 0);
            IElement element3 = pView.GraphicsContainer.FindFrame(pView.FocusMap) as IElement;
            IEnvelope bounds = new EnvelopeClass();
            element3.QueryBounds(pView.ScreenDisplay, bounds);
            IPolygon outline = new PolygonClass();
            element2.QueryOutline(pView.ScreenDisplay, outline);
            pView.GraphicsContainer.DeleteElement(element2);
            point = new PointClass();
            point.X = bounds.XMax - outline.Envelope.Width;
            point.Y = bounds.YMax + 0.1;
            element2.Geometry = point;
            pView.GraphicsContainer.AddElement(element2, 0);
            pView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private bool ExistDx(IActiveView pView)
        {
            IMap focusMap = pView.FocusMap;
            int layerCount = focusMap.LayerCount;
            for (int i = 0; i < layerCount; i++)
            {
                ILayer layer = focusMap.get_Layer(i);
                if (layer.Name == this._layerName)
                {
                    return layer.Visible;
                }
                if ((layer is ICompositeLayer) && this.FindDx(layer as ICompositeLayer))
                {
                    return true;
                }
            }
            return false;
        }

        private bool FindDx(ICompositeLayer pLayer)
        {
            for (int i = 0; i < pLayer.Count; i++)
            {
                ILayer layer = pLayer.get_Layer(i);
                if (layer.Name == this._layerName)
                {
                    return layer.Visible;
                }
                if ((layer is ICompositeLayer) && this.FindDx(layer as ICompositeLayer))
                {
                    return true;
                }
            }
            return false;
        }

        private IColor GetDefaultTextColor()
        {
            try
            {
                Color black = Color.Black;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = black.R;
                color2.Green = black.G;
                color2.Blue = black.B;
                return color2;
            }
            catch
            {
                return null;
            }
        }

        private ITextSymbol GetDefaultTextSymbol()
        {
            try
            {
                ITextSymbol symbol = new TextSymbolClass();
                symbol.Angle = 0.0;
                symbol.Color = this.GetDefaultTextColor();
                symbol.Size = 20.0;
                symbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
                symbol.VerticalAlignment = esriTextVerticalAlignment.esriTVABaseline;
                IFontDisp font = null;
                if (symbol.Font == null)
                {
                    font = new StdFontClass() as IFontDisp;
                }
                else
                {
                    font = symbol.Font;
                }
                font.Name = "宋体";
                font.Size = 20M;
                font.Bold = true;
                symbol.Font = font;
                return symbol;
            }
            catch
            {
                return null;
            }
        }

        public string LayerName
        {
            set
            {
                this._layerName = value;
            }
        }
    }
}

