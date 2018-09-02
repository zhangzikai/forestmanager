namespace Cartography.Element
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using stdole;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class Coordinate : BaseTool
    {
        private IHookHelper m_hookHelper;
        private INewBezierCurveFeedback mFeedback;
        private bool mInUsing;
        private IPoint mStartPoint;

        public Coordinate()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "";
            base.m_name = "";
            try
            {
                base.m_cursor = new Cursor(base.GetType(), base.GetType().Name + ".cur");
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
        }

        ~Coordinate()
        {
            AOUninitialize.Shutdown();
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
                stdole.IFontDisp font = null;
                if (symbol.Font == null)
                {
                    font = new StdFontClass() as stdole.IFontDisp;
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

        public override void OnClick()
        {
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.m_hookHelper = new HookHelperClass();
                this.m_hookHelper.Hook = hook;
                if (this.m_hookHelper.ActiveView == null)
                {
                    this.m_hookHelper = null;
                }
            }
            catch
            {
                this.m_hookHelper = null;
            }
            if (this.m_hookHelper == null)
            {
                base.m_enabled = false;
            }
            else
            {
                base.m_enabled = true;
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button == 1)
            {
                IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                IActiveView focusMap = this.m_hookHelper.FocusMap as IActiveView;
                IPoint point2 = focusMap.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                string str = Math.Round(point2.X, 0).ToString();
                string str2 = Math.Round(point2.Y, 0).ToString();
                ITextElement element = new TextElementClass();
                element.Text = "+";
                IElementProperties properties = element as IElementProperties;
                properties.Name = "zb";
                properties.CustomProperty = "X:" + str + "    Y:" + str2;
                IFormattedTextSymbol defaultTextSymbol = this.GetDefaultTextSymbol() as IFormattedTextSymbol;
                element.Symbol = defaultTextSymbol;
                IElement element2 = element as IElement;
                element2.Geometry = point;
                IPolygon outline = new PolygonClass();
                element2.QueryOutline(this.m_hookHelper.ActiveView.ScreenDisplay, outline);
                IArea area = outline as IArea;
                IPoint point3 = new PointClass();
                point3.X = point.X - (area.Centroid.X - point.X);
                point3.Y = point.Y - (area.Centroid.Y - point.Y);
                element2.Geometry = point3;
                this.m_hookHelper.ActiveView.GraphicsContainer.AddElement(element2, 0);
                this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
        }

        private void ResetObject()
        {
            this.mInUsing = false;
            if (this.mFeedback != null)
            {
                try
                {
                    this.mFeedback.Stop();
                }
                catch (Exception)
                {
                }
                this.mFeedback = null;
            }
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public override bool Enabled
        {
            get
            {
                return ((this.m_hookHelper != null) && (this.m_hookHelper.Hook is IPageLayoutControl));
            }
        }
    }
}

