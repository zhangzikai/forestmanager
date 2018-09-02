namespace Cartography
{
    using Cartography.Base;
    using Cartography.Element;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.ComponentModel;
    using Utilities;

    /// <summary>
    /// 元素管理类
    /// </summary>
    public class ElementManager : IDisposable
    {
        private Component component = new Component();
        private bool disposed;
        private const string mClassName = "Cartography.ElementManager";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public void CreateCoordinate(IPageLayout pPageLayout)
        {
            try
            {
                new AutoCoordinate(pPageLayout).OnClick();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementManager", "CreateTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void CreateLegend(IActiveView pActiveView, IPageLayoutControl pPageControl)
        {
            DevLegend legend = new DevLegend();
            legend.PageLayoutControl = pPageControl;
            legend.ShowDialog();
            legend.Dispose();
        }

        public void CreateMapTitle(IActiveView pActiveView)
        {
            DevText text = new DevText();
            text.ActiveView = pActiveView;
            text.ShowDialog();
            text.Dispose();
        }

        public void CreateNorthArrow(IActiveView pActiveView)
        {
            DevNorthArrowSelector selector = new DevNorthArrowSelector();
            selector.ActiveView = pActiveView;
            selector.ShowDialog();
            selector.Dispose();
        }

        public void CreateScaleBar(IActiveView pActiveView)
        {
            DevScaleBar bar = new DevScaleBar();
            bar.ActiveView = pActiveView;
            bar.ShowDialog();
            bar.Dispose();
        }

        public void CreateTable(IPageLayout pPageLayout, TableInfo pTableInfo)
        {
            try
            {
                ElementService service = new ElementService();
                service.CreateBmpPictureElement(pPageLayout, pTableInfo);
                service.Dispose();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementManager", "CreateTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void CreateTableEx(IPageLayout pPageLayout, TableInfo pTableInfo)
        {
            try
            {
                ElementService service = new ElementService();
                service.CreateBmpPictureElementEx(pPageLayout, pTableInfo);
                service.Dispose();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementManager", "CreateTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            AOUninitialize.Shutdown();
            if (!this.disposed && disposing)
            {
                this.component.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// 设置元素的属性
        /// </summary>
        /// <param name="pPageLayout"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public void SetProperty(IPageLayoutControl3 pPageLayout, double pX, double pY)
        {
            try
            {//UIDClass类唯一标识符对象。
                UID uid = new UIDClass();
                uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";
                IFeatureLayer layer2 = pPageLayout.ActiveView.FocusMap.get_Layers(uid, true).Next() as IFeatureLayer;
                ITopologyContainer featureDataset = layer2.FeatureClass.FeatureDataset as ITopologyContainer;
                IActiveView activeView = pPageLayout.ActiveView;
                IPageLayout pageLayout = pPageLayout.PageLayout;
                IGraphicsContainerSelect graphicsContainer = pPageLayout.GraphicsContainer as IGraphicsContainerSelect;
                IPoint point = new PointClass();
                point.X = pX;
                point.Y = pY;
                graphicsContainer.UnselectAllElements();
                IEnumElement element = pPageLayout.GraphicsContainer.LocateElements(point, featureDataset.DefaultClusterTolerance);
                IElement element2 = null;
                element2 = element.Next();
                if (element2 != null)
                {
                    if (element2 is IMapSurroundFrame)
                    {
                        IMapSurroundFrame frame = (IMapSurroundFrame) element2;
                        IMapSurround mapSurround = frame.MapSurround;
                        if (mapSurround is IMarkerNorthArrow)
                        {
                            DevNorthArrowSelector selector = new DevNorthArrowSelector();
                            selector.ActiveView = activeView;
                            selector.PreMapSurroundFrame = frame;
                            selector.ShowDialog();
                            selector.Dispose();
                        }
                        else if (mapSurround is IScaleText)
                        {
                            Cartography.Element.ScaleText text = new Cartography.Element.ScaleText();
                            text.ActiveView = activeView;
                            text.PreMapsurroundFrame = frame;
                            text.ShowDialog();
                            text.Dispose();
                            text = null;
                        }
                        else if (mapSurround is IScaleBar)
                        {
                            DevScaleBar bar = new DevScaleBar();
                            bar.PreMapsurroundFrame = frame;
                            bar.ActiveView = activeView;
                            bar.ShowDialog();
                            bar.Dispose();
                        }
                        else if (mapSurround is ILegend)
                        {
                            DevLegend legend = new DevLegend();
                            legend.PageLayoutControl = pPageLayout;
                            legend.PreMapSurroundFrame = frame;
                            legend.ShowDialog();
                            legend.Dispose();
                        }
                    }
                    if (element2 is ITextElement)
                    {
                        DevText text2 = new DevText();
                        text2.ActiveView = activeView;
                        text2.PreElement = (ITextElement) element2;
                        text2.ShowDialog();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementManager", "SetProperty", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

