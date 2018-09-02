namespace Cartography.Element
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using stdole;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;

    public sealed class TF : BaseTool
    {
        private IHookHelper m_hookHelper;
        private INewBezierCurveFeedback mFeedback;
        private bool mInUsing;
        private IPoint mStartPoint;

        public TF()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "";
            base.m_name = "";
            try
            {
                base.m_cursor = new System.Windows.Forms.Cursor(base.GetType(), base.GetType().Name + ".cur");
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
        }

        ~TF()
        {
            AOUninitialize.Shutdown();
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

        private string GetTF()
        {
            string str = "";
            if (this.m_hookHelper.Hook is IMapControl4)
            {
                IMapControl4 hook = this.m_hookHelper.Hook as IMapControl4;
                if (hook.CustomProperty != null)
                {
                    str = hook.CustomProperty.ToString();
                }
                return str;
            }
            if (this.m_hookHelper.Hook is IPageLayoutControl3)
            {
                IPageLayoutControl3 control2 = this.m_hookHelper.Hook as IPageLayoutControl3;
                if (control2.CustomProperty != null)
                {
                    str = control2.CustomProperty.ToString();
                }
                return str;
            }
            if (this.m_hookHelper.Hook is IToolbarControl2)
            {
                IToolbarControl2 control3 = this.m_hookHelper.Hook as IToolbarControl2;
                if (control3.CustomProperty != null)
                {
                    str = control3.CustomProperty.ToString();
                }
            }
            return str;
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
                    IActiveView focusMap = this.m_hookHelper.ActiveView.FocusMap as IActiveView;
                    IEnvelope extent = focusMap.Extent;
                    ISpatialFilter filter = new SpatialFilterClass();
                    filter.Geometry = extent;
                    IFeatureClass class2 = EditTask.EditWorkspace.OpenFeatureClass("INDEX_A_10K");
                    IGeoDataset dataset = class2 as IGeoDataset;
                    filter.Geometry.Project(dataset.SpatialReference);
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelEnvelopeIntersects;
                    IFeatureCursor cursor = class2.Search(filter, false);
                    IFeature feature = cursor.NextFeature();
                    string str = "";
                    while (feature != null)
                    {
                        object obj2 = feature.get_Value(1);
                        object obj3 = feature.get_Value(2);
                        if ((obj2 != null) && (obj3 != null))
                        {
                            string str2 = str;
                            str = str2 + obj3.ToString() + "(" + obj2.ToString() + ")," + Environment.NewLine;
                        }
                        feature = cursor.NextFeature();
                    }
                    int startIndex = str.LastIndexOf(',');
                    str = str.Remove(startIndex);
                    if (str != "")
                    {
                        ITextElement element = new TextElementClass();
                        element.Text = str;
                        IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                        IElement element2 = element as IElement;
                        element2.Geometry = point;
                        IFormattedTextSymbol defaultTextSymbol = this.GetDefaultTextSymbol() as IFormattedTextSymbol;
                        element.Symbol = defaultTextSymbol;
                        this.m_hookHelper.ActiveView.GraphicsContainer.AddElement(element2, 0);
                        this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        this.mStartPoint = null;
                    }
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

