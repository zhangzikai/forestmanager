namespace Cartography
{
    using Cartography.Base;
    using Cartography.Business;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using Microsoft.VisualBasic.Compatibility.VB6;
    using stdole;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using Utilities;

    internal class ElementService : IDisposable
    {
        private Component component = new Component();
        private bool disposed;
        private const string mClassName = "Cartography.ElementService";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public IElement CreateBmpPictureElement(IPageLayout pPageLayout, TableInfo pTi)
        {
            try
            {
                IActiveView view = pPageLayout as IActiveView;
                TableDrawer drawer = new TableDrawer(view.FocusMap, pTi);
                IActiveView focusMap = (IActiveView) view.FocusMap;
                Metafile img = drawer.Drawtable(focusMap.Extent);
                if (img == null)
                {
                    return null;
                }
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(1, 1);
                Graphics graphics = Graphics.FromImage(image);
                double dValue = ((float) img.Width) / graphics.DpiX;
                double num2 = ((float) img.Height) / graphics.DpiY;
                IUnitConverter converter = new UnitConverterClass();
                dValue = converter.ConvertUnits(dValue, esriUnits.esriInches, pPageLayout.Page.Units);
                num2 = converter.ConvertUnits(num2, esriUnits.esriInches, pPageLayout.Page.Units);
                IGraphicsContainer container = pPageLayout as IGraphicsContainer;
                IElement element = container.FindFrame(view.FocusMap) as IElement;
                IEnvelope envelope = element.Geometry.Envelope;
                double xMin = envelope.XMax - dValue;
                double yMin = envelope.YMin;
                IElement element2 = new EmfPictureElementClass();
                IOlePictureElement element3 = element2 as IOlePictureElement;
                IEnvelope envelope2 = new EnvelopeClass();
                envelope2.PutCoords(xMin, yMin, envelope.XMax, yMin + num2);
                element2.Geometry = envelope2;
                IPictureDisp pictureDisp = (IPictureDisp) Support.ImageToIPictureDisp(img);
                element3.ImportPicture(pictureDisp);
                container.AddElement(element2, 0);
                view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, envelope2);
                return element2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementService", "CreateBmpPictureElement", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public IElement CreateBmpPictureElementEx(IPageLayout pPageLayout, TableInfo pTi)
        {
            try
            {
                IActiveView view = pPageLayout as IActiveView;
                TableDrawer drawer = new TableDrawer(view.FocusMap, pTi);
                IActiveView focusMap = (IActiveView) view.FocusMap;
                Metafile img = drawer.DrawtableEx(focusMap.Extent);
                if (img == null)
                {
                    return null;
                }
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(1, 1);
                Graphics graphics = Graphics.FromImage(image);
                double dValue = ((float) img.Width) / graphics.DpiX;
                double num2 = ((float) img.Height) / graphics.DpiY;
                IUnitConverter converter = new UnitConverterClass();
                dValue = converter.ConvertUnits(dValue, esriUnits.esriInches, pPageLayout.Page.Units);
                num2 = converter.ConvertUnits(num2, esriUnits.esriInches, pPageLayout.Page.Units);
                IGraphicsContainer container = pPageLayout as IGraphicsContainer;
                IElement element = container.FindFrame(view.FocusMap) as IElement;
                IEnvelope envelope = element.Geometry.Envelope;
                double xMin = envelope.XMax - dValue;
                double yMin = envelope.YMin;
                IElement element2 = new EmfPictureElementClass();
                IOlePictureElement element3 = element2 as IOlePictureElement;
                IEnvelope envelope2 = new EnvelopeClass();
                envelope2.PutCoords(xMin, yMin, envelope.XMax, yMin + num2);
                element2.Geometry = envelope2;
                IPictureDisp pictureDisp = (IPictureDisp) Support.ImageToIPictureDisp(img);
                element3.ImportPicture(pictureDisp);
                container.AddElement(element2, 0);
                view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, envelope2);
                return element2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementService", "CreateBmpPictureElement", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        /// <summary>
        /// 创建图例的方法。
        /// </summary>
        /// <param name="pControl"></param>
        /// <param name="pLegend"></param>
        /// <param name="pLegendItems"></param>
        /// <returns></returns>
        public IMapSurroundFrame CreateLegend(IPageLayoutControl pControl, ILegend pLegend, List<ILegendItem> pLegendItems)
        {
            try
            {//IGraphicsContainer接口提供对控制图形容器的成员的访问。管理图形元素集合的对象实现此接口。例如，PageLayout，Map和FDOGraphicsLayer对象都实现了这个接口来提供对他们管理的图形元素的访问。
                IGraphicsContainer graphicsContainer = pControl.GraphicsContainer;
                IActiveView activeView = pControl.ActiveView;
                //IMapFrame接口提供对控制地图元素对象的成员的访问。IMapFrame是MapFrame对象的默认界面。该界面的主要目的是让开发人员访问存储在框架内的地图对象，并将其定位器矩形相关联。
                IMapFrame frame = graphicsContainer.FindFrame(pControl.ActiveView.FocusMap) as IMapFrame;
                pLegend.Map = pControl.ActiveView.FocusMap;
                pLegend.ClearItems();
                foreach (ILegendItem item in pLegendItems)
                {
                    pLegend.AddItem(item);
                }
                pLegend.Refresh();
                ///标识某一个类或接口的id,如果某一个组件在你的系统中注册了，系统就会分配给它一个uid，唯一标识它通过这个uid就可以获得这个组件
                UID clsid = new UIDClass();
                clsid.Value = "esriCarto.Legend";
                //IMapSurroundFrame界面提供对控制地图环绕元素界面的成员的访问。IMapSurroundFrame是MapSurroundFrame对象的默认界面。使用此界面获取或更新存储在框架内的环绕对象（北箭头，比例尺或图例），或者要获取或更新与环绕相关联的MapFrame时。
                IMapSurroundFrame frame2 = frame.CreateSurroundFrame(clsid, null);
                frame2.MapSurround = pLegend;
                IElement element = frame2 as IElement;
                IEnvelope oldBounds = new EnvelopeClass();

                ////test
                ////oldBounds.PutCoords(5.0, 5.0, 10.0, 15.0);
                oldBounds.PutCoords(0.5, 0.5, 1, 2);

                pLegend.QueryBounds(pControl.ActiveView.ScreenDisplay, oldBounds, oldBounds);
                element.Geometry = oldBounds;
                element.Activate(pControl.ActiveView.ScreenDisplay);
                graphicsContainer.AddElement(element, 0);
                return frame2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementService", "CreateLegend", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public IMapSurroundFrame CreateMapsurround(IPageLayout pPageLayout, IMap pMap, IStyleGalleryItem pItem)
        {
            if ((pPageLayout != null) && (pMap != null))
            {
                IMapSurround item = (IMapSurround) pItem.Item;
                IGraphicsContainer container = pPageLayout as IGraphicsContainer;
                IActiveView view = pPageLayout as IActiveView;
                IMapFrame frame = container.FindFrame(pMap) as IMapFrame;
                item.Map = pMap;
                IMapSurroundFrame frame2 = new MapSurroundFrameClass();
                frame2.MapFrame = frame;
                frame2.MapSurround = item;
                IElement element = frame2 as IElement;
                IEnvelope oldBounds = new EnvelopeClass();
                item.QueryBounds(view.ScreenDisplay, oldBounds, oldBounds);
                double xMin = view.Extent.XMin + (view.Extent.Width / 2.0);
                double yMin = view.Extent.YMax - (view.Extent.Height / 2.0);
                double xMax = xMin + oldBounds.Width;
                double yMax = yMin + oldBounds.Height;
                oldBounds.PutCoords(xMin, yMin, xMax, yMax);
                element.Geometry = oldBounds;
                container.AddElement(element, 0);
                return frame2;
            }
            return null;
        }

        /// <summary>
        /// 创建指北针的方法
        /// </summary>
        /// <param name="pPageLayout"></param>
        /// <param name="pMap"></param>
        /// <param name="pMapsurround"></param>
        /// <param name="pEnvelope"></param>
        /// <returns></returns>
        public IMapSurroundFrame CreateMapsurround(IPageLayout pPageLayout, IMap pMap, IMapSurround pMapsurround, IEnvelope pEnvelope)
        {
            if ((pPageLayout == null) || (pMap == null))
            {
                return null;
            }
            try
            {
                IGraphicsContainer container = pPageLayout as IGraphicsContainer;
                IMapFrame frame = container.FindFrame(pMap) as IMapFrame;
                IMapSurroundFrame frame2 = new MapSurroundFrameClass();
                frame2.MapFrame = frame;
                frame2.MapSurround = pMapsurround;
                IElement element = frame2 as IElement;
                element.Geometry = pEnvelope;
                container.AddElement(element, 0);
                return frame2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.ElementService", "CreateMapsurround", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
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

        public void SetPro(IMapSurroundFrame pSurroundFrame, IStyleGalleryItem pItem, IActiveView pActiveView)
        {
            IMapSurround item = (IMapSurround) pItem.Item;
            pSurroundFrame.MapSurround = item;
            IEnvelope oldBounds = new EnvelopeClass();
            item.QueryBounds(pActiveView.ScreenDisplay, oldBounds, oldBounds);
            IElement element = pSurroundFrame as IElement;
            IEnvelope envelope = element.Geometry.Envelope;
            double xMax = envelope.XMin + oldBounds.Width;
            double yMax = envelope.YMin + oldBounds.Height;
            envelope.PutCoords(envelope.XMin, envelope.YMin, xMax, yMax);
            element.Geometry = envelope;
        }

        public static string StyleGalleryFile
        {
            get
            {
                return (UtilFactory.GetConfigOpt().RootPath + UtilFactory.GetConfigOpt().GetConfigValue("SystemStylePath"));
            }
        }

        /// <summary>
        /// 因为无法获取项目的样式文件路径，因此直接使用固定的样式文件路径
        /// </summary>
        public static string StyleGalleryFile1
        {
            get
            {
                return (UtilFactory.GetConfigOpt().RootPath + @"Style\ESRI.ServerStyle");
            }
        }
    }
}

