namespace Print
{
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Output;
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using Utilities;

    public class ImageExport : IDisposable
    {
        private Component component = new Component();
        private bool disposed;
        private const string mClassName = "Print.ImageExport";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const uint SPI_GETFONTSMOOTHING = 0x4a;
        private const uint SPI_SETFONTSMOOTHING = 0x4b;
        private const uint SPIF_UPDATEINIFILE = 1;

        private void DisableFontSmoothing()
        {
            int pvParam = 0;
            SystemParametersInfo(0x4b, 0, ref pvParam, 1);
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

        private void EnableFontSmoothing()
        {
            int pvParam = 0;
            SystemParametersInfo(0x4b, 1, ref pvParam, 1);
        }

        public bool ExportActiveViewParameterized(IActiveView pActiveView, long pOutputResolution, long pResampleRatio, string pFormat, string pFileName, bool bClipToGraphicsExtent, bool bPage)
        {
            try
            {
                IEnvelope envelope2;
                tagRECT grect;
                tagRECT exportFrame;
                IActiveView docActiveView = pActiveView;
                IExport export = new ExportBMPClass();
                bool flag = false;
                if (this.GetFontSmoothing())
                {
                    flag = true;
                    this.DisableFontSmoothing();
                    if (this.GetFontSmoothing())
                    {
                        return false;
                    }
                }
                if (pFormat == "BMP")
                {
                    export = new ExportBMPClass();
                }
                else if (pFormat == "TIFF")
                {
                    export = new ExportTIFFClass();
                }
                else if (pFormat == "PNG")
                {
                    export = new ExportPNGClass();
                }
                else if (pFormat == "GIF")
                {
                    export = new ExportGIFClass();
                }
                else if (pFormat == "JPEG")
                {
                    export = new ExportJPEGClass();
                }
                else if (pFormat == "PDF")
                {
                    export = new ExportPDFClass();
                }
                IOutputRasterSettings displayTransformation = docActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                long resampleRatio = displayTransformation.ResampleRatio;
                this.SetOutputQuality(docActiveView, pResampleRatio);
                export.ExportFileName = pFileName;
                long dC = GetDC(0);
                long deviceCaps = GetDeviceCaps((int) dC, 0x58);
                ReleaseDC(0, (int) dC);
                export.Resolution = pOutputResolution;
                IPage page = null;
                if (docActiveView is IPageLayout)
                {
                    exportFrame = docActiveView.ExportFrame;
                    page = ((IPageLayout) docActiveView).Page;
                }
                else
                {
                    exportFrame = docActiveView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
                    IObjectCopy copy = new ObjectCopyClass();
                    object focusMap = docActiveView.FocusMap;
                    object pInObject = copy.Copy(focusMap);
                    IPageLayoutControl3 control = new PageLayoutControlClass();
                    object pOverwriteObject = control.ActiveView.FocusMap;
                    copy.Overwrite(pInObject, ref pOverwriteObject);
                    control.ActiveView.Extent = docActiveView.Extent;
                    page = control.Page;
                }
                if (page == null)
                {
                    return false;
                }
                IEnvelope envelope = new EnvelopeClass() as IEnvelope;
                if (bClipToGraphicsExtent && (docActiveView is IPageLayout))
                {
                    IEnvelope graphicsExtent = this.GetGraphicsExtent(docActiveView);
                    IPageLayout layout = docActiveView as PageLayout;
                    IUnitConverter converter = new UnitConverterClass();
                    envelope.XMin = 0.0;
                    envelope.YMin = 0.0;
                    envelope.XMax = (converter.ConvertUnits(graphicsExtent.XMax, layout.Page.Units, esriUnits.esriInches) * export.Resolution) - (converter.ConvertUnits(graphicsExtent.XMin, layout.Page.Units, esriUnits.esriInches) * export.Resolution);
                    envelope.YMax = (converter.ConvertUnits(graphicsExtent.YMax, layout.Page.Units, esriUnits.esriInches) * export.Resolution) - (converter.ConvertUnits(graphicsExtent.YMin, layout.Page.Units, esriUnits.esriInches) * export.Resolution);
                    grect.bottom = ((int) envelope.YMax) + 1;
                    grect.left = (int) envelope.XMin;
                    grect.top = (int) envelope.YMin;
                    grect.right = ((int) envelope.XMax) + 1;
                    envelope2 = graphicsExtent;
                }
                else
                {
                    int num5 = 0;
                    int num6 = 0;
                    if (bPage)
                    {
                        double num8;
                        double num9;
                        double num7 = (pOutputResolution * 37.79524) / ((double) deviceCaps);
                        page.QuerySize(out num8, out num9);
                        double num10 = num8 * num7;
                        double num11 = num9 * num7;
                        num6 = Convert.ToInt32(num10);
                        num5 = Convert.ToInt32(num11);
                    }
                    else
                    {
                        double num12 = pOutputResolution / deviceCaps;
                        double d = exportFrame.bottom * num12;
                        num5 = (int) Math.Truncate(d);
                        double num14 = exportFrame.right * num12;
                        num6 = (int) Math.Truncate(num14);
                    }
                    grect.bottom = num5;
                    grect.left = 0;
                    grect.top = 0;
                    grect.right = num6;
                    envelope.PutCoords((double) grect.left, (double) grect.top, (double) grect.right, (double) grect.bottom);
                    envelope2 = null;
                }
                export.PixelBounds = envelope;
                long num2 = export.StartExporting();
                docActiveView.Output((int) num2, (int) export.Resolution, ref grect, envelope2, null);
                export.FinishExporting();
                export.Cleanup();
                this.SetOutputQuality(docActiveView, resampleRatio);
                if (flag)
                {
                    this.EnableFontSmoothing();
                    flag = false;
                    this.GetFontSmoothing();
                }
                envelope2 = null;
                envelope = null;
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Print.ImageExport", "ExportActiveViewParameterized", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        [DllImport("User32.dll")]
        public static extern int GetDC(int hWnd);
        [DllImport("GDI32.dll")]
        public static extern int GetDeviceCaps(int hdc, int nIndex);
        private bool GetFontSmoothing()
        {
            int pvParam = 0;
            SystemParametersInfo(0x4a, 0, ref pvParam, 0);
            return (pvParam > 0);
        }

        private IEnvelope GetGraphicsExtent(IActiveView docActiveView)
        {
            IEnvelope envelope = new EnvelopeClass();
            IEnvelope bounds = new EnvelopeClass();
            IDisplay screenDisplay = docActiveView.ScreenDisplay;
            IGraphicsContainer container = docActiveView as IGraphicsContainer;
            container.Reset();
            for (IElement element = container.Next(); element != null; element = container.Next())
            {
                element.QueryBounds(screenDisplay, bounds);
                envelope.Union(bounds);
            }
            return envelope;
        }

        public static double GetRadio(int pRosolution)
        {
            int dC = GetDC(0);
            int deviceCaps = GetDeviceCaps(dC, 0x58);
            ReleaseDC(0, dC);
            double num3 = double.Parse(pRosolution.ToString());
            double num4 = double.Parse(deviceCaps.ToString());
            return (num3 / num4);
        }

        public tagRECT GetTagRect(IActiveView pActiveView, double pResolution)
        {
            IEnvelope graphicsExtent = this.GetGraphicsExtent(pActiveView);
            IPageLayout layout = pActiveView as PageLayout;
            IUnitConverter converter = new UnitConverterClass();
            IEnvelope envelope2 = new EnvelopeClass();
            tagRECT grect = new tagRECT();
            envelope2.XMin = 0.0;
            envelope2.YMin = 0.0;
            envelope2.XMax = (converter.ConvertUnits(graphicsExtent.XMax, layout.Page.Units, esriUnits.esriInches) * pResolution) - (converter.ConvertUnits(graphicsExtent.XMin, layout.Page.Units, esriUnits.esriInches) * pResolution);
            envelope2.YMax = (converter.ConvertUnits(graphicsExtent.YMax, layout.Page.Units, esriUnits.esriInches) * pResolution) - (converter.ConvertUnits(graphicsExtent.YMin, layout.Page.Units, esriUnits.esriInches) * pResolution);
            grect.bottom = (int) envelope2.YMax;
            grect.left = (int) envelope2.XMin;
            grect.top = (int) envelope2.YMin;
            grect.right = (int) envelope2.XMax;
            return grect;
        }

        [DllImport("User32.dll")]
        public static extern int ReleaseDC(int hWnd, int hDC);
        private void SetOutputQuality(IActiveView docActiveView, long iResampleRatio)
        {
            IOutputRasterSettings displayTransformation;
            if (docActiveView is IMap)
            {
                displayTransformation = docActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                displayTransformation.ResampleRatio = (int) iResampleRatio;
            }
            else if (docActiveView is IPageLayout)
            {
                IMapFrame frame;
                IActiveView map;
                displayTransformation = docActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                displayTransformation.ResampleRatio = (int) iResampleRatio;
                IGraphicsContainer container = docActiveView as IGraphicsContainer;
                container.Reset();
                for (IElement element = container.Next(); element != null; element = container.Next())
                {
                    if (element is IMapFrame)
                    {
                        frame = element as IMapFrame;
                        map = frame.Map as IActiveView;
                        displayTransformation = map.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                        displayTransformation.ResampleRatio = (int) iResampleRatio;
                    }
                }
                frame = null;
                container = null;
                map = null;
            }
            displayTransformation = null;
        }

        [DllImport("user32.dll", SetLastError=true)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int pvParam, uint fWinIni);
    }
}

