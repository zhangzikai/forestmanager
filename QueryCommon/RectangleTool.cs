namespace QueryCommon
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class RectangleTool : BaseTool
    {
        private IHookHelper m_HookHelper;
        private INewEnvelopeFeedback mFeedback;
        private IFillSymbol mFillSymbol;
        private bool mInUsing;
        private UserControlInfo mMyParent;
        private IPoint mPoint;

        public RectangleTool()
        {
            try
            {
                base.m_caption = "选择范围";
                base.m_name = "RectangleTool";
                base.m_cursor = new Cursor(base.GetType(), "Rectangle.cur");
                this.m_HookHelper = new HookHelperClass();
            }
            catch (Exception)
            {
            }
        }

        public override bool Deactivate()
        {
            try
            {
                this.ResetTool();
                this.mFillSymbol = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //protected override void Finalize()
        //{
        //    try
        //    {
        //        this.m_HookHelper = null;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        ~RectangleTool() {
            try
            {
                this.m_HookHelper = null;
            }
            catch (Exception)
            {
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int GetCapture();
        public override void OnClick()
        {
            try
            {
                if (this.mFillSymbol == null)
                {
                    IRgbColor color = new RgbColorClass();
                    color.Red = 0xff;
                    color.Green = 0;
                    color.Blue = 0;
                    ISimpleLineSymbol symbol = null;
                    symbol = new SimpleLineSymbolClass();
                    symbol.Style = esriSimpleLineStyle.esriSLSSolid;
                    symbol.Color = color;
                    symbol.Width = 1.0;
                    ISimpleFillSymbol symbol2 = null;
                    symbol2 = new SimpleFillSymbolClass();
                    symbol2.Style = esriSimpleFillStyle.esriSFSNull;
                    symbol2.Outline = symbol;
                    this.mFillSymbol = symbol2;
                }
            }
            catch (Exception)
            {
            }
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.m_HookHelper.Hook = hook;
            }
            catch (Exception)
            {
            }
        }

        public override void OnKeyDown(int keyCode, int shift)
        {
            try
            {
                if (keyCode == 0x1b)
                {
                    this.ResetTool();
                }
                else if (keyCode == 0x10)
                {
                    if (this.mFeedback != null)
                    {
                        this.mFeedback.Constraint = esriEnvelopeConstraints.esriEnvelopeConstraintsSquare;
                    }
                }
                else if ((keyCode == 0x11) && (this.mFeedback != null))
                {
                    this.mFeedback.Constraint = esriEnvelopeConstraints.esriEnvelopeConstraintsAspect;
                }
            }
            catch (Exception)
            {
            }
        }

        public override void OnKeyUp(int keyCode, int shift)
        {
            try
            {
                if (this.mFeedback != null)
                {
                    this.mFeedback.Constraint = esriEnvelopeConstraints.esriEnvelopeConstraintsNone;
                }
            }
            catch (Exception)
            {
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                if ((this.m_HookHelper.ActiveView != null) && (button == 1))
                {
                    this.ResetTool();
                    this.mPoint = this.m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                    this.mFeedback = new NewEnvelopeFeedbackClass();
                    this.mFeedback.Display = this.m_HookHelper.ActiveView.ScreenDisplay;
                    this.mFillSymbol = (IFillSymbol) this.mFeedback.Symbol;
                    IRgbColor color = new RgbColorClass();
                    color.Red = 0xff;
                    color.Green = 0;
                    color.Blue = 0;
                    ISimpleLineSymbol symbol = null;
                    symbol = new SimpleLineSymbolClass();
                    symbol.Style = esriSimpleLineStyle.esriSLSSolid;
                    symbol.Color = color;
                    symbol.Width = 1.0;
                    this.mFeedback.Start(this.mPoint);
                    this.mInUsing = true;
                    SetCapture(this.m_HookHelper.ActiveView.ScreenDisplay.hWnd);
                }
            }
            catch (Exception)
            {
            }
        }

        public override void OnMouseMove(int button, int shift, int x, int y)
        {
            try
            {
                if (this.mInUsing)
                {
                    if (this.mFeedback != null)
                    {
                        this.mFeedback.MoveTo(this.m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y));
                        IEnvelope data = new EnvelopeClass();
                        IPoint point = this.m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                        if (point.X < this.mPoint.X)
                        {
                            data.XMin = point.X;
                            data.XMax = this.mPoint.X;
                        }
                        if (point.Y < this.mPoint.Y)
                        {
                            data.YMin = point.Y;
                            data.YMax = this.mPoint.Y;
                        }
                        if (point.X >= this.mPoint.X)
                        {
                            data.XMin = this.mPoint.X;
                            data.XMax = point.X;
                        }
                        if (point.Y >= this.mPoint.Y)
                        {
                            data.YMin = this.mPoint.Y;
                            data.YMax = point.Y;
                        }
                        IGeometry geometry = data;
                        if ((((geometry != null) && !geometry.IsEmpty) && ((geometry.Envelope != null) && (geometry.Envelope.Width > 0.0))) && (geometry.Envelope.Height > 0.0))
                        {
                            this.m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewNone, data, null);
                            this.mMyParent.PointLocation2 = (IEnvelope) geometry;
                        }
                    }
                    else
                    {
                        this.mInUsing = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public override void OnMouseUp(int button, int shift, int x, int y)
        {
            try
            {
                if (this.mInUsing && (this.mFeedback != null))
                {
                    IGeometry geometry = null;
                    geometry = this.mFeedback.Stop();
                    this.ResetTool();
                    if ((((geometry != null) && !geometry.IsEmpty) && ((geometry.Envelope != null) && (geometry.Envelope.Width > 0.0))) && (geometry.Envelope.Height > 0.0))
                    {
                        this.mMyParent.PointLocation2 = (IEnvelope) geometry;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int ReleaseCapture();
        private void ResetTool()
        {
            try
            {
                if (this.m_HookHelper.ActiveView.ScreenDisplay.hWnd == GetCapture())
                {
                    ReleaseCapture();
                }
                this.mInUsing = false;
                if (this.mFeedback != null)
                {
                    try
                    {
                        this.mFeedback.Stop();
                        this.mFeedback = null;
                    }
                    catch (Exception)
                    {
                    }
                }
                this.m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
            }
            catch (Exception)
            {
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int SetCapture(int hWnd);

        public override bool Enabled
        {
            get
            {
                try
                {
                    if (this.m_HookHelper.ActiveView == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public UserControlInfo ParentForm
        {
            set
            {
                this.mMyParent = value;
            }
        }
    }
}

