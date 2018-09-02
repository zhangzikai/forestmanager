namespace Cartography.Element
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using stdole;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class AutoCoordinate
    {
        private static List<IElement> _elements = new List<IElement>();
        private IPageLayout _pageLayout;

        public AutoCoordinate(IPageLayout pPageLayout)
        {
            this._pageLayout = pPageLayout;
        }

        private IElement AddElement(double pX, double pY, double pMapX, double pMapY)
        {
            ITextElement element = new TextElementClass();
            string str = Math.Round(pMapX, 0).ToString();
            string str2 = Math.Round(pMapY, 0).ToString();
            element.Text = "+";
            IElementProperties properties = element as IElementProperties;
            properties.Name = "zb";
            properties.CustomProperty = "X:" + str + "    Y:" + str2;
            IFormattedTextSymbol defaultTextSymbol = this.GetDefaultTextSymbol() as IFormattedTextSymbol;
            element.Symbol = defaultTextSymbol;
            IElement element2 = element as IElement;
            IPoint point = new PointClass();
            point.X = pX;
            point.Y = pY;
            element2.Geometry = point;
            IActiveView view = this._pageLayout as IActiveView;
            IPolygon outline = new PolygonClass();
            element2.QueryOutline(view.ScreenDisplay, outline);
            IArea area = outline as IArea;
            point = new PointClass();
            point.X = pX - (area.Centroid.X - pX);
            point.Y = pY - (area.Centroid.Y - pY);
            element2.Geometry = point;
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
                symbol.Size = 30.0;
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
                font.Size = 30M;
                font.Bold = true;
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
                int num3;
                int num4;
                IActiveView view = this._pageLayout as IActiveView;
                for (int i = _elements.Count - 1; i >= 0; i--)
                {
                    IElement element = _elements[i];
                    view.GraphicsContainer.DeleteElement(element);
                }
                _elements.Clear();
                IMapFrame frame = view.GraphicsContainer.FindFrame(view.FocusMap) as IMapFrame;
                IElement element2 = frame as IElement;
                IPolygon outline = new PolygonClass();
                element2.QueryOutline(view.ScreenDisplay, outline);
                double xMin = outline.Envelope.XMin;
                IActiveView focusMap = view.FocusMap as IActiveView;
                IEnvelope extent = focusMap.Extent;
                IPoint mapPoint = new PointClass();
                mapPoint.SpatialReference = focusMap.FocusMap.SpatialReference;
                mapPoint.X = extent.XMin;
                mapPoint.Y = extent.YMax;
                focusMap.ScreenDisplay.DisplayTransformation.FromMapPoint(mapPoint, out num3, out num4);
                IElement element3 = this.AddElement(outline.Envelope.XMin, outline.Envelope.YMax, extent.XMin, extent.YMax);
                view.GraphicsContainer.AddElement(element3, 0);
                _elements.Add(element3);
                element3 = this.AddElement(outline.Envelope.XMin, outline.Envelope.YMin, extent.XMin, extent.YMin);
                view.GraphicsContainer.AddElement(element3, 0);
                _elements.Add(element3);
                element3 = this.AddElement(outline.Envelope.XMax, outline.Envelope.YMax, extent.XMax, extent.YMax);
                view.GraphicsContainer.AddElement(element3, 0);
                _elements.Add(element3);
                element3 = this.AddElement(outline.Envelope.XMax, outline.Envelope.YMin, extent.XMax, extent.YMin);
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

