namespace GISControlsClass
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlOverView : UserControlBase1
    {
        protected AxToolbarControl axToolbarControl1;
        private IContainer components;
        private Label label1;
        public AxMapControl MapControlOverView;
        private const string mClassName = "GISControlsClass.UserControlOverview";
        private IElement mElement;
        private IEnvelope mEnvelope;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public UserControlOverView()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 绘制包络线
        /// </summary>
        /// <param name="pEnv"></param>
        /// <param name="pUnit"></param>
        public void DrawEnvelope(IEnvelope pEnv, esriUnits pUnit)
        {
            try
            {
                if ((((this.mEnvelope == null) || (this.mEnvelope.XMin != pEnv.XMin)) || ((this.mEnvelope.YMin != pEnv.YMin) || (this.mEnvelope.XMax != pEnv.XMax))) || (this.mEnvelope.YMax != pEnv.YMax))
                {
                    this.mEnvelope = pEnv;
                    IActiveView activeView = this.MapControlOverView.ActiveView;
                    IBasicMap map = this.MapControlOverView.Map as IBasicMap;
                    if ((map != null) && (map.LayerCount > 0))
                    {
                        IGraphicsLayer basicGraphicsLayer = map.BasicGraphicsLayer;
                        IGraphicsLayer pGLayer = map.BasicGraphicsLayer;
                        int num = 10;
                        if (pUnit == esriUnits.esriMiles)
                        {
                            num = 5;
                        }
                        else
                        {
                            num = 10;
                        }
                        if (this.mElement != null)
                        {
                            //IGraphicsContainer接口提供对控制图形容器的成员的访问。主要是管理map上Element对象的。
                            //管理图形元素集合的对象实现此接口。例如，PageLayout，Map和FDOGraphicsLayer对象都实现了这个接口来提供对他们管理的图形元素的访问。
                            //PageLayout对象包含一组Element对象，包括MapFrames，MapSurroundFrames和GraphicElements，如PictureElement，MarkerElement和LineElement。该界面的成员提供对Elements的访问。
                            //当使用此接口将元素添加到在corrdinate系统（如FDOGraphicsLayer和CompositeGraphicsLayer）中操作的图层类型时，元素必须实现IGraphicElement。
                            IGraphicsContainer container = pGLayer as IGraphicsContainer;
                            try
                            {
                                //IGraphicsContainer.DeleteElement方法删除给定的元素。
                                container.DeleteElement(this.mElement);
                            }
                            catch (Exception)
                            {
                            }
                            this.mElement = this.DrawEnvelopeElement(this.MapControlOverView.Map, pEnv, pGLayer, false);
                            IEnvelope extent = activeView.Extent;
                            if (pEnv.XMin < extent.XMin)
                            {
                                extent.XMin = pEnv.XMin - num;
                            }
                            if (pEnv.YMin < extent.YMin)
                            {
                                extent.YMin = pEnv.YMin - num;
                            }
                            if (pEnv.XMax > extent.XMax)
                            {
                                extent.XMax = pEnv.XMax + num;
                            }
                            if (pEnv.YMax > extent.YMax)
                            {
                                extent.YMax = pEnv.YMax + num;
                            }
                            activeView.FullExtent = extent;
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, this.mElement, activeView.FullExtent);
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.mElement, activeView.FullExtent);
                            activeView.Refresh();
                        }
                        else
                        {
                            this.mElement = this.DrawEnvelopeElement(this.MapControlOverView.Map, pEnv, pGLayer, false);
                            IEnvelope envelope2 = activeView.Extent;
                            if (pEnv.XMin < envelope2.XMin)
                            {
                                envelope2.XMin = pEnv.XMin - num;
                            }
                            if (pEnv.YMin < envelope2.YMin)
                            {
                                envelope2.YMin = pEnv.YMin - num;
                            }
                            if (pEnv.XMax > envelope2.XMax)
                            {
                                envelope2.XMax = pEnv.XMax + num;
                            }
                            if (pEnv.YMax > envelope2.YMax)
                            {
                                envelope2.YMax = pEnv.YMax + num;
                            }
                            activeView.FullExtent = envelope2;
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, this.mElement, activeView.FullExtent);
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.mElement, activeView.FullExtent);
                            activeView.Refresh();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private IElement DrawEnvelopeElement(IMap pMap, IEnvelope pEnvelope, IGraphicsLayer pGLayer, bool pClearFlag)
        {
            try
            {
                IPoint inPoint = new PointClass();
                IPoint point2 = new PointClass();
                IPoint point3 = new PointClass();
                IPoint point4 = new PointClass();
                inPoint.PutCoords(pEnvelope.XMin, pEnvelope.YMin);
                point2.PutCoords(pEnvelope.XMin, pEnvelope.YMax);
                point3.PutCoords(pEnvelope.XMax, pEnvelope.YMax);
                point4.PutCoords(pEnvelope.XMax, pEnvelope.YMin);
                IPointCollection points = new PolygonClass();
                object before = Missing.Value;
                object after = Missing.Value;
                points.AddPoint(inPoint, ref before, ref after);
                points.AddPoint(point2, ref before, ref after);
                points.AddPoint(point3, ref before, ref after);
                points.AddPoint(point4, ref before, ref after);
                points.AddPoint(inPoint, ref before, ref after);
                ISimpleFillSymbol polySymbol = this.GetPolySymbol(null, null);
                IGeometry geometry = points as IGeometry;
                IElement element = new PolygonElementClass();
                element.Geometry = geometry;
                IFillShapeElement element2 = element as IFillShapeElement;
                element2.Symbol = polySymbol;
                IGraphicsContainer container = pGLayer as IGraphicsContainer;
                if (pClearFlag)
                {
                    container.DeleteAllElements();
                }
                container.AddElement(element, 0);
                return element;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private ILineSymbol GetLineSymbol(IRgbColor pRgbColor, double iWidth)
        {
            try
            {
                if (pRgbColor == null)
                {
                    pRgbColor = new RgbColorClass();
                    pRgbColor.Red = 0xff;
                    pRgbColor.Green = 0;
                    pRgbColor.Blue = 0;
                }
                ILineSymbol symbol = null;
                symbol = new CartographicLineSymbolClass();
                symbol.Width = iWidth;
                symbol.Color = pRgbColor;
                return symbol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlOverview", "GetLineSymbol", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private SimpleFillSymbol GetPolySymbol(IRgbColor pBackRgbColor, IRgbColor pBorderRgbColor)
        {
            try
            {
                if (pBackRgbColor == null)
                {
                    pBackRgbColor = new RgbColorClass();
                    pBackRgbColor.NullColor = true;
                }
                SimpleFillSymbol symbol = new SimpleFillSymbolClass();
                symbol.Color = pBackRgbColor;
                symbol.Outline = this.GetLineSymbol(pBorderRgbColor, 1.2);
                return symbol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlOverview", "GetPolySymbol", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlOverView));
            this.MapControlOverView = new AxMapControl();
            this.axToolbarControl1 = new AxToolbarControl();
            this.label1 = new Label();
            this.MapControlOverView.BeginInit();
            this.axToolbarControl1.BeginInit();
            base.SuspendLayout();
            this.MapControlOverView.Dock = DockStyle.Fill;
            this.MapControlOverView.Location = new System.Drawing.Point(1, 30);
            this.MapControlOverView.Name = "MapControlOverView";
            this.MapControlOverView.OcxState = (AxHost.State)resources.GetObject("MapControlOverView.OcxState");
            this.MapControlOverView.Size = new Size(0x120, 0x106);
            this.MapControlOverView.TabIndex = 14;
            this.axToolbarControl1.Dock = DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(1, 1);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = (AxHost.State)resources.GetObject("axToolbarControl1.OcxState");
            this.axToolbarControl1.Size = new Size(0x120, 0x1c);
            this.axToolbarControl1.TabIndex = 13;
            this.label1.Dock = DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(1, 0x1d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x120, 1);
            this.label1.TabIndex = 15;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.Controls.Add(this.MapControlOverView);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.axToolbarControl1);
            base.Name = "UserControlOverview";
            base.Padding = new Padding(1);
            base.Size = new Size(290, 0x125);
            this.MapControlOverView.EndInit();
            this.axToolbarControl1.EndInit();
            base.ResumeLayout(false);
        }
    }
}

