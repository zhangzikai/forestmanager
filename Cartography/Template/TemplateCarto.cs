namespace Cartography.Template
{
    using Cartography;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;
    using Utilities;

    internal class TemplateCarto
    {
        private const string mClassName = "Cartography.Template.TemplateCarto4";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public void Carto(IPageLayoutControl3 pPageLayoutControl, string sTemplateFile)
        {
            try
            {
                IMap focusMap = pPageLayoutControl.ActiveView.FocusMap;
                IActiveView view = focusMap as IActiveView;
                IEnvelope extent = view.Extent;
                IMap map2 = focusMap;
                pPageLayoutControl.LoadMxFile(sTemplateFile, "");
                IMapFrame frame = pPageLayoutControl.GraphicsContainer.FindFrame(pPageLayoutControl.ActiveView.FocusMap) as IMapFrame;
                frame.Map = map2;
                pPageLayoutControl.ActiveView.Activate(pPageLayoutControl.hWnd);
                pPageLayoutControl.ActiveView.FocusMap = map2;
                IGraphicsContainer pageLayout = pPageLayoutControl.PageLayout as IGraphicsContainer;
                pageLayout.Reset();
                for (IElement element2 = pageLayout.Next(); element2 != null; element2 = pageLayout.Next())
                {
                    if (element2 is IMapSurroundFrame)
                    {
                        IMapSurroundFrame frame2 = (IMapSurroundFrame) element2;
                        IMapSurround mapSurround = frame2.MapSurround;
                        if (mapSurround is IScaleText)
                        {
                            mapSurround.Map = map2;
                        }
                    }
                }
                view = pPageLayoutControl.ActiveView.FocusMap as IActiveView;
                view.Extent = extent;
                view.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                pPageLayoutControl.ZoomToWholePage();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.TemplateCarto4", "Carto", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Clone(object pSourceObj, object pTargetObj)
        {
            if ((pSourceObj == null) || (pTargetObj == null))
            {
                throw new Exception("对象为空！");
            }
            IObjectCopy copy = new ObjectCopyClass();
            copy.Copy(pSourceObj);
            copy.Overwrite(pSourceObj, ref pTargetObj);
        }

        public ILayer FindFeatureLayer(IMap pMap, IFeatureLayer pFeatureLayer)
        {
            try
            {
                if (pMap != null)
                {
                    if (pMap.LayerCount <= 0)
                    {
                        return null;
                    }
                    ILayer layer = null;
                    for (int i = 0; i <= (pMap.LayerCount - 1); i++)
                    {
                        layer = pMap.get_Layer(i);
                        if (layer is IFeatureLayer)
                        {
                            if (layer.Name.Equals(pFeatureLayer.Name))
                            {
                                IAttributeTable table = layer as IAttributeTable;
                                IAttributeTable table2 = pFeatureLayer as IAttributeTable;
                                IDataset attributeTable = table.AttributeTable as IDataset;
                                IDataset dataset2 = table2.AttributeTable as IDataset;
                                if (attributeTable.Name.Equals(dataset2.Name))
                                {
                                    return layer;
                                }
                            }
                        }
                        else if (layer is IGroupLayer)
                        {
                            layer = this.FindFeatureLayerGroupRecursion(layer as IGroupLayer, pFeatureLayer);
                            if (layer != null)
                            {
                                return layer;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.TemplateCarto4", "FindFeatureLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return null;
        }

        private ILayer FindFeatureLayerGroupRecursion(IGroupLayer pGroupLayer, IFeatureLayer pFeatureLayer)
        {
            try
            {
                if (pGroupLayer != null)
                {
                    ICompositeLayer layer = pGroupLayer as ICompositeLayer;
                    if (layer.Count <= 0)
                    {
                        return null;
                    }
                    ILayer layer2 = null;
                    int index = 0;
                    for (index = 0; index <= (layer.Count - 1); index++)
                    {
                        layer2 = layer.get_Layer(index);
                        if (layer2 is IFeatureLayer)
                        {
                            if (layer2.Name.Equals(pFeatureLayer.Name))
                            {
                                IAttributeTable table = layer2 as IAttributeTable;
                                IAttributeTable table2 = pFeatureLayer as IAttributeTable;
                                IDataset attributeTable = table.AttributeTable as IDataset;
                                IDataset dataset2 = table2.AttributeTable as IDataset;
                                if (attributeTable.Name.Equals(dataset2.Name))
                                {
                                    return layer2;
                                }
                            }
                        }
                        else if (layer2 is IGroupLayer)
                        {
                            layer2 = this.FindFeatureLayerGroupRecursion(layer2 as IGroupLayer, pFeatureLayer);
                            if (layer2 != null)
                            {
                                return layer2;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.TemplateCarto4", "FindFeatureLayerGroupRecursion", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return null;
        }

        public void NormalCarto(IPageLayoutControl3 pPageLayoutControl)
        {
            IGraphicsContainer pageLayout = pPageLayoutControl.PageLayout as IGraphicsContainer;
            pageLayout.Reset();
            for (IElement element = pageLayout.Next(); element != null; element = pageLayout.Next())
            {
                if (element is IMapFrame)
                {
                    double num;
                    double num2;
                    pPageLayoutControl.Page.QuerySize(out num, out num2);
                    double num3 = UnitService.ConvertUnit(1.0, esriUnits.esriCentimeters, pPageLayoutControl.Page.Units);
                    double xMin = num3;
                    double yMin = num3;
                    double xMax = num - num3;
                    double yMax = num2 - num3;
                    IPolygon geometry = element.Geometry as IPolygon;
                    IEnvelope envelope = geometry.Envelope;
                    envelope.PutCoords(xMin, yMin, xMax, yMax);
                    element.Geometry = envelope;
                }
                else
                {
                    pageLayout.DeleteElement(element);
                    Marshal.ReleaseComObject(element);
                    pageLayout.Reset();
                }
            }
            pPageLayoutControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
    }
}

