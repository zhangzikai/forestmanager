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

    /// <summary>
    /// 地图的注释类
    /// </summary>
    public sealed class Annotate : BaseTool
    {
        private IHookHelper m_hookHelper;
        private INewBezierCurveFeedback mFeedback;
        private bool mInUsing;
        private IPoint mStartPoint;

        /// <summary>
        /// 地图的注释类：构造器
        /// </summary>
        public Annotate()
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

        ~Annotate()
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
                symbol.Size = 10.0;
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
                this.mStartPoint = new PointClass();
                this.mStartPoint = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                this.mFeedback = new NewBezierCurveFeedbackClass();
                this.mFeedback.Display = this.m_hookHelper.ActiveView.ScreenDisplay;
                this.mFeedback.Start(this.mStartPoint);
                this.mInUsing = true;
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            if (this.mInUsing)
            {
                if (Button != 1)
                {
                    this.ResetObject();
                    this.mStartPoint = null;
                }
                else if (this.mFeedback != null)
                {
                    this.mFeedback.MoveTo(this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y));
                }
                else
                {
                    this.mInUsing = false;
                }
            }
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            if (((Button == 1) && this.mInUsing) && (this.mStartPoint != null))
            {
                try
                {
                    ITextElement element = new TextElementClass();
                    element.Text = "请输入文本";
                    IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    IElement element2 = element as IElement;
                    element2.Geometry = point;
                    ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
                    symbol.Color = this.GetDefaultOutlineColor();
                    symbol.Style = esriSimpleLineStyle.esriSLSSolid;
                    symbol.Width = 1.0;
                    ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                    symbol2.Color = this.GetDefaultFillColor();
                    symbol2.Style = esriSimpleFillStyle.esriSFSSolid;
                    symbol2.Outline = symbol;
                    IBalloonCallout callout = new BalloonCalloutClass();
                    callout.AnchorPoint = this.mStartPoint;
                    callout.Style = esriBalloonCalloutStyle.esriBCSRectangle;
                    callout.Symbol = symbol2;
                    IFormattedTextSymbol defaultTextSymbol = this.GetDefaultTextSymbol() as IFormattedTextSymbol;
                    defaultTextSymbol.Background = callout as ITextBackground;
                    element.Symbol = defaultTextSymbol;
                    this.m_hookHelper.ActiveView.GraphicsContainer.AddElement(element2, 0);
                    DevText text = new DevText();
                    text.ActiveView = this.m_hookHelper.ActiveView;
                    text.PreElement = element;
                    if (text.ShowDialog() == DialogResult.OK)
                    {
                        if (string.IsNullOrEmpty(element.Text))
                        {
                            this.m_hookHelper.ActiveView.GraphicsContainer.DeleteElement(element2);
                        }
                        IGraphicsContainerSelect graphicsContainer = (IGraphicsContainerSelect) this.m_hookHelper.ActiveView.GraphicsContainer;
                        graphicsContainer.UnselectAllElements();
                        graphicsContainer.SelectElement(element2);
                    }
                    else
                    {
                        this.m_hookHelper.ActiveView.GraphicsContainer.DeleteElement(element2);
                    }
                    text.Dispose();
                    text = null;
                    this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                    this.mStartPoint = null;
                }
                catch
                {
                }
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

