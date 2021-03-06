﻿namespace TopologyCheck.Error
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using TopologyCheck.Properties;

    public class ErrManager
    {
        public static Dictionary<int, List<IElement>> ErrElements = new Dictionary<int, List<IElement>>();

        public static void AddErrAreaElement(IActiveView pActiveView, IFeature pFeature, ref List<IElement> pElements)
        {
            IGeometry shapeCopy = pFeature.ShapeCopy;
            IElement element = CreatePolygonElement(pActiveView, shapeCopy);
            (pActiveView as IGraphicsContainer).AddElement(element, 0);
            pElements.Add(element);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, pActiveView.Extent);
        }

        public static void AddErrPointElement(IActiveView pActiveView, string pPos, ISpatialReference pDataSR, ref List<IElement> pElements)
        {
            string[] strArray = pPos.Split(new char[] { ';' });
            IGraphicsContainer container = pActiveView as IGraphicsContainer;
            foreach (string str in strArray)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray2 = str.Split(new char[] { ',' });
                    double pX = double.Parse(strArray2[0]);
                    double pY = double.Parse(strArray2[1]);
                    IElement item = CreateMarkerElement(pActiveView, pX, pY, Resources.Err, pDataSR);
                    pElements.Add(item);
                    container.AddElement(item, 0);
                }
            }
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, pActiveView.Extent);
        }

        public static void AddErrTopoElement(IActiveView pActiveView, IGeometry pGeo, ref List<IElement> pElements)
        {
            IElement element = CreatePolygonElement(pActiveView, pGeo);
            (pActiveView as IGraphicsContainer).AddElement(element, 0);
            pElements.Add(element);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, pActiveView.Extent);
        }

        public static void AddErrTopoElement(IActiveView pActiveView, object errs, IFeature pFeature)
        {
            IList<IGeometry> list = (IList<IGeometry>) errs;
            if ((list != null) && (list.Count >= 1))
            {
                IGraphicsContainer container = pActiveView as IGraphicsContainer;
                List<IElement> list2 = null;
                if (ErrElements.ContainsKey(pFeature.OID))
                {
                    list2 = ErrElements[pFeature.OID];
                    foreach (IElement element in list2)
                    {
                        container.DeleteElement(element);
                    }
                    list2.Clear();
                }
                else
                {
                    list2 = new List<IElement>();
                    ErrElements.Add(pFeature.OID, list2);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    IElement element2 = CreateElement(pActiveView, list[i]);
                    if (element2 == null)
                    {
                        return;
                    }
                    container.AddElement(element2, 0);
                    list2.Add(element2);
                }
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, pActiveView.Extent);
            }
        }

        private static IElement CreateElement(IActiveView pActiveView, IGeometry pGeo)
        {
            if (pGeo is IPolygon)
            {
                return CreatePolygonElement(pActiveView, pGeo);
            }
            if ((pGeo is IPolyline) || (pGeo is ILine))
            {
                return CreateLineElement(pActiveView, pGeo);
            }
            if (pGeo is IPoint)
            {
                return CreatePointElement(pActiveView, pGeo);
            }
            return null;
        }

        private static IElement CreateLineElement(IActiveView pActiveView, IGeometry pGeo)
        {
            IRgbColor color = new RgbColorClass();
            color.Blue = 0xff;
            color.Green = 0;
            color.Red = 0xc5;
            IColor color2 = color;
            ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
            symbol.Style = esriSimpleLineStyle.esriSLSSolid;
            symbol.Color = color2;
            symbol.Width = 2.0;
            pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeo, pActiveView.FocusMap.SpatialReference);
            IElement element = new LineElementClass();
            element.Geometry = pGeo;
            ILineElement element2 = element as ILineElement;
            element2.Symbol = symbol;
            return element;
        }

        public static IElement CreateMarkerElement(IActiveView pActiveView, double pX, double pY, Bitmap pMap, ISpatialReference pDataSR)
        {
            new MarkerElementClass();
            IPoint point = new PointClass();
            point.X = pX;
            point.Y = pY;
            IGeometry pGeo = point;
            pGeo.SpatialReference = pDataSR;
            return CreatePointElement(pActiveView, pGeo);
        }

        private static IElement CreatePointElement(IActiveView pActiveView, IGeometry pGeo)
        {
            pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeo, pActiveView.FocusMap.SpatialReference);
            IMarkerElement element = new MarkerElementClass();
            IElement element2 = element as IElement;
            IRgbColor color = new RgbColorClass();
            color.Blue = 0xff;
            color.Green = 0;
            color.Red = 0xc5;
            IColor color2 = color;
            ISimpleMarkerSymbol symbol = new SimpleMarkerSymbolClass();
            symbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            symbol.Color = color2;
            symbol.Size = 8.0;
            element.Symbol = symbol;
            element2.Geometry = pGeo;
            return element2;
        }

        public static IElement CreatePolygonElement(IActiveView pActiveView, IGeometry pGeo)
        {
            IRgbColor color = new RgbColorClass();
            color.Blue = 0xff;
            color.Green = 0;
            color.Red = 0xc5;
            IColor color2 = color;
            ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
            symbol.Style = esriSimpleLineStyle.esriSLSSolid;
            symbol.Color = color2;
            symbol.Width = 2.0;
            ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
            symbol2.Style = esriSimpleFillStyle.esriSFSBackwardDiagonal;
            IRgbColor color3 = new RgbColorClass();
            color.Blue = 0xc5;
            color.Green = 0;
            color.Red = 0xff;
            symbol2.Color = color3;
            symbol2.Outline = symbol;
            pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeo, pActiveView.FocusMap.SpatialReference);
            ISimpleFillSymbol symbol3 = symbol2;
            IElement element = new PolygonElementClass();
            element.Geometry = pGeo;
            IFillShapeElement element2 = element as IFillShapeElement;
            element2.Symbol = symbol3;
            return element;
        }

        public static void ZoomToErr(IActiveView pActiveView, IFeature pFeature)
        {
            IGeometry shapeCopy = pFeature.ShapeCopy;
            ZoomToErr(pActiveView, shapeCopy);
        }

        public static void ZoomToErr(IActiveView pActiveView, IGeometry pGeo)
        {
            pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeo, pActiveView.FocusMap.SpatialReference);
            IEnvelope envelope = new EnvelopeClass();
            envelope.SpatialReference = pActiveView.FocusMap.SpatialReference;
            envelope.PutCoords(pGeo.Envelope.XMin, pGeo.Envelope.YMin, pGeo.Envelope.XMax, pGeo.Envelope.YMax);
            envelope.Expand(1.3, 1.3, true);
            pActiveView.Extent = envelope;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, pActiveView.Extent);
        }
    }
}

