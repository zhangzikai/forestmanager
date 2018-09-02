namespace Identify
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class FlashObjectsClass
    {
        private ISymbol lineSymbol;
        private IMapControl2 mapControl2;
        private List<IGeometry> pointsFlashObject = new List<IGeometry>();
        private ISymbol pointSymbol;
        private List<IGeometry> polygonsFlashObject = new List<IGeometry>();
        private List<IGeometry> polylinesFlashObject = new List<IGeometry>();
        private ISymbol regionSymbol;
        private IScreenDisplay screenDisplay;

        public FlashObjectsClass()
        {
            this.InitialSymbols();
        }

        public void AddGeometry(IGeometry geo)
        {
            switch (geo.GeometryType)
            {
                case esriGeometryType.esriGeometryPoint:
                    this.pointsFlashObject.Add(geo);
                    return;

                case esriGeometryType.esriGeometryMultipoint:
                    break;

                case esriGeometryType.esriGeometryPolyline:
                    this.polylinesFlashObject.Add(geo);
                    return;

                case esriGeometryType.esriGeometryPolygon:
                    this.polygonsFlashObject.Add(geo);
                    break;

                default:
                    return;
            }
        }

        private IFillSymbol DefineFillSymbol(IColor color, esriSimpleFillStyle style, ILineSymbol outLineSymbol)
        {
            ISimpleFillSymbol symbol = new SimpleFillSymbolClass();
            symbol.Color = color;
            symbol.Style = style;
            symbol.Outline = outLineSymbol;
            return symbol;
        }

        private ILineSymbol DefineLineOutLineSymbol()
        {
            ISimpleLineSymbol lineLayer = new SimpleLineSymbolClass();
            lineLayer.Width = 5.5;
            lineLayer.Color = this.DefineRgbColor(0, 0, 0);
            lineLayer.Style = esriSimpleLineStyle.esriSLSSolid;
            ISimpleLineSymbol symbol2 = new SimpleLineSymbolClass();
            symbol2.Width = 4.0;
            symbol2.Color = this.DefineRgbColor(0, 0x80, 0);
            symbol2.Style = esriSimpleLineStyle.esriSLSSolid;
            IMultiLayerLineSymbol symbol3 = new MultiLayerLineSymbolClass();
            symbol3.AddLayer(lineLayer);
            symbol3.AddLayer(symbol2);
            return symbol3;
        }

        private ILineSymbol DefineLineSymbol(double width, IColor color, esriSimpleLineStyle style)
        {
            ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
            symbol.Width = width;
            symbol.Color = color;
            symbol.Style = style;
            return symbol;
        }

        private IMarkerSymbol DefinePointSymbol(double size, IColor color, esriSimpleMarkerStyle style, ILineSymbol outLineSymbol)
        {
            ISimpleMarkerSymbol symbol = new SimpleMarkerSymbolClass();
            IMarkerSymbol symbol2 = symbol;
            symbol.Size = size;
            symbol.Color = color;
            symbol.Style = style;
            if (outLineSymbol == null)
            {
                symbol.Outline = false;
                return symbol2;
            }
            symbol.Outline = true;
            symbol.OutlineColor = outLineSymbol.Color;
            symbol.OutlineSize = outLineSymbol.Width;
            return symbol2;
        }

        private IColor DefineRgbColor(int r, int g, int b)
        {
            if ((((r > 0xff) || (r < 0)) || ((g > 0xff) || (g < 0))) || ((b > 0xff) || (b < 0)))
            {
                throw new Exception("颜色值不合法!");
            }
            IRgbColor color = new RgbColorClass();
            color.Red = r;
            color.Green = g;
            color.Blue = b;
            return color;
        }

        public void FlashObjects()
        {
            this.screenDisplay.StartDrawing(this.screenDisplay.hDC, -1);
            this.screenDisplay.SetSymbol(this.regionSymbol);
            for (int i = 0; i < this.polygonsFlashObject.Count; i++)
            {
                this.screenDisplay.DrawPolygon(this.polygonsFlashObject[i]);
            }
            this.screenDisplay.SetSymbol(this.lineSymbol);
            for (int j = 0; j < this.polylinesFlashObject.Count; j++)
            {
                this.screenDisplay.DrawPolyline(this.polylinesFlashObject[j]);
            }
            this.screenDisplay.SetSymbol(this.pointSymbol);
            for (int k = 0; k < this.pointsFlashObject.Count; k++)
            {
                this.screenDisplay.DrawPoint(this.pointsFlashObject[k]);
            }
            Thread.Sleep(500);
            this.screenDisplay.FinishDrawing();
            this.mapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
        }

        public void FlashObjects(LayerIdentifiedResult layerFlash)
        {
            this.screenDisplay.StartDrawing(this.screenDisplay.hDC, -1);
            switch (layerFlash.GeometryType)
            {
                case LayerFeatureType.Point:
                    this.screenDisplay.SetSymbol(this.pointSymbol);
                    break;

                case LayerFeatureType.Polyline:
                    this.screenDisplay.SetSymbol(this.lineSymbol);
                    break;

                case LayerFeatureType.Polygon:
                    this.screenDisplay.SetSymbol(this.regionSymbol);
                    break;

                default:
                    return;
            }
            List<IFeatureIdentifyObj> identifiedFeatureObjList = layerFlash.IdentifiedFeatureObjList;
            for (int i = 0; i < identifiedFeatureObjList.Count; i++)
            {
                IFeature row = (identifiedFeatureObjList[i] as IRowIdentifyObject).Row as IFeature;
                switch (layerFlash.GeometryType)
                {
                    case LayerFeatureType.Point:
                        this.screenDisplay.DrawPoint(row.Shape);
                        break;

                    case LayerFeatureType.Polyline:
                        this.screenDisplay.DrawPolyline(row.Shape);
                        break;

                    case LayerFeatureType.Polygon:
                        this.screenDisplay.DrawPolygon(row.Shape);
                        break;
                }
            }
            Thread.Sleep(500);
            this.screenDisplay.FinishDrawing();
            this.mapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
        }

        public void Init()
        {
            this.pointsFlashObject.Clear();
            this.polylinesFlashObject.Clear();
            this.polygonsFlashObject.Clear();
        }

        private void InitialSymbols()
        {
            IColor color = this.DefineRgbColor(0, 0x80, 0);
            IColor color2 = this.DefineRgbColor(0, 0, 0);
            ILineSymbol outLineSymbol = this.DefineLineSymbol(1.0, color2, esriSimpleLineStyle.esriSLSSolid);
            this.pointSymbol = this.DefinePointSymbol(13.0, color, esriSimpleMarkerStyle.esriSMSCircle, outLineSymbol) as ISymbol;
            this.lineSymbol = this.DefineLineOutLineSymbol() as ISymbol;
            this.regionSymbol = this.DefineFillSymbol(color, esriSimpleFillStyle.esriSFSSolid, outLineSymbol) as ISymbol;
        }

        public IMapControl2 MapControl
        {
            set
            {
                this.mapControl2 = value;
                this.screenDisplay = value.ActiveView.ScreenDisplay;
            }
        }
    }
}

