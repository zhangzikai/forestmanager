namespace Cartography.Element
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using stdole;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class AutoCoordinate1
    {
        private static List<IElement> _elements = new List<IElement>();
        private IPageLayout _pageLayout;

        public AutoCoordinate1(IPageLayout pPageLayout)
        {
            this._pageLayout = pPageLayout;
        }

        private IElement AddElement(double pX, double pY, double pMapX, double pMapY)
        {
            IPoint point = new PointClass();
            point.X = pX;
            point.Y = pY;
            ITextElement element = new TextElementClass();
            string str = Math.Round(pMapX, 0).ToString();
            string str2 = Math.Round(pMapY, 0).ToString();
            element.Text = "+";
            IElementProperties properties = element as IElementProperties;
            properties.Name = "zb";
            properties.CustomProperty = "X:" + str + "    Y:" + str2;
            IElement element2 = element as IElement;
            element2.Geometry = point;
            ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
            symbol.Color = this.GetDefaultOutlineColor();
            symbol.Style = esriSimpleLineStyle.esriSLSSolid;
            symbol.Width = 1.0;
            ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
            symbol2.Color = this.GetDefaultFillColor();
            symbol2.Style = esriSimpleFillStyle.esriSFSNull;
            symbol2.Outline = symbol;
            ILineCallout callout = new LineCalloutClass();
            callout.AnchorPoint = point;
            callout.Style = esriLineCalloutStyle.esriLCSBase;
            callout.Border = symbol2;
            IFormattedTextSymbol defaultTextSymbol = this.GetDefaultTextSymbol() as IFormattedTextSymbol;
            defaultTextSymbol.Background = callout as ITextBackground;
            element.Symbol = defaultTextSymbol;
            return element2;
        }

        private IColor GetDefaultFillColor()
        {
            try
            {
                Color info = SystemColors.Info;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = info.R;
                color2.Green = info.G;
                color2.Blue = info.B;
                return color2;
            }
            catch
            {
                return null;
            }
        }

        private IColor GetDefaultOutlineColor()
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
                symbol.Size = 10.0;
                symbol.Text = "文本";
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
                font.Size = 10M;
                font.Bold = false;
                font.Italic = false;
                font.Underline = false;
                font.Strikethrough = false;
                symbol.Font = font;
                IFormattedTextSymbol symbol2 = symbol as IFormattedTextSymbol;
                symbol2.Direction = esriTextDirection.esriTDHorizontal;
                ISimpleTextSymbol symbol3 = symbol as ISimpleTextSymbol;
                symbol3.XOffset = 0.0;
                symbol3.YOffset = 0.0;
                return symbol;
            }
            catch
            {
                return null;
            }
        }

        public void OnClick()
        {
            try
            {
                IActiveView view = this._pageLayout as IActiveView;
                for (int i = _elements.Count - 1; i >= 0; i--)
                {
                    IElement element = _elements[i];
                    view.GraphicsContainer.DeleteElement(element);
                }
                _elements.Clear();
                IElement element2 = view.GraphicsContainer.FindFrame(view.FocusMap) as IElement;
                IEnvelope bounds = new EnvelopeClass();
                element2.QueryBounds(view.ScreenDisplay, bounds);
                IActiveView focusMap = view.FocusMap as IActiveView;
                IEnvelope extent = focusMap.Extent;
                IElement element3 = this.AddElement(bounds.XMin, bounds.YMax, extent.XMin, extent.YMax);
                view.GraphicsContainer.AddElement(element3, 0);
                _elements.Add(element3);
                element3 = this.AddElement(bounds.XMin, bounds.YMin, extent.XMin, extent.YMin);
                view.GraphicsContainer.AddElement(element3, 0);
                _elements.Add(element3);
                element3 = this.AddElement(bounds.XMax, bounds.YMax, extent.XMax, extent.YMax);
                view.GraphicsContainer.AddElement(element3, 0);
                _elements.Add(element3);
                element3 = this.AddElement(bounds.XMax, bounds.YMin, extent.XMax, extent.YMin);
                view.GraphicsContainer.AddElement(element3, 0);
                _elements.Add(element3);
                view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            catch
            {
            }
        }
    }
}

