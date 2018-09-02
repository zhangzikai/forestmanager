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
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using Utilities;

    public class ClsPrint : IDisposable
    {
        private IActiveView _activeView;
        private PrintDocument _document;
        private short _index;
        private IPageLayoutControl _pageLayoutControl;
        private Component component = new Component();
        private bool disposed;
        private const string mClassName = "Print.ClsPrint";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

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

        public void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                tagRECT grect;
                double num3;
                double num4;
                double num5;
                double num6;
                this._index = (short) (this._index + 1);
                this._document.DocumentName = this._index.ToString();
                short resolution = this._pageLayoutControl.Printer.Resolution;
                IEnvelope deviceBounds = new EnvelopeClass();
                IPage page = this._pageLayoutControl.PageLayout.Page;
                IPrinter printer = this._pageLayoutControl.Printer;
                page.GetDeviceBounds(printer, 0, MapPageSet.OverLap, resolution, deviceBounds);
                deviceBounds.QueryCoords(out num3, out num4, out num5, out num6);
                grect.bottom = (int) (num6 - num4);
                grect.left = 0;
                grect.top = 0;
                grect.right = (int) (num5 - num3);
                if ((grect.left != grect.right) && (grect.top != grect.bottom))
                {
                    IEnvelope pageBounds = new EnvelopeClass();
                    page.GetPageBounds(printer, this._index, MapPageSet.OverLap, pageBounds);
                    IntPtr hdc = e.Graphics.GetHdc();
                    this._pageLayoutControl.ActiveView.Output(hdc.ToInt32(), resolution, ref grect, pageBounds, null);
                    e.Graphics.ReleaseHdc(hdc);
                }
                short num = this._pageLayoutControl.get_PrinterPageCount(MapPageSet.OverLap);
                if (this._index < num)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                    this._index = 0;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Print.ClsPrint", "Document_PrintPage", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Print()
        {
            try
            {
                if ((this._activeView != null) && !(this._activeView is IPageLayout))
                {
                    IObjectCopy copy = new ObjectCopyClass();
                    object focusMap = this._activeView.FocusMap;
                    object pInObject = copy.Copy(focusMap);
                    this._pageLayoutControl = new PageLayoutControlClass();
                    object pOverwriteObject = this._pageLayoutControl.ActiveView.FocusMap;
                    copy.Overwrite(pInObject, ref pOverwriteObject);
                    this._pageLayoutControl.ActiveView.Extent = this._activeView.Extent;
                }
                PrintDialog dialog = new PrintDialog();
                dialog.AllowSomePages = true;
                dialog.ShowHelp = false;
                dialog.Document = this._document;
                dialog.Document.PrintPage += new PrintPageEventHandler(this.Document_PrintPage);
                dialog.Document.PrinterSettings.PrintRange = PrintRange.AllPages;
                short num = this._pageLayoutControl.get_PrinterPageCount(MapPageSet.OverLap);
                dialog.Document.PrinterSettings.MinimumPage = 1;
                dialog.Document.PrinterSettings.MaximumPage = num;
                dialog.Document.PrinterSettings.FromPage = 1;
                dialog.Document.PrinterSettings.ToPage = num;
                dialog.Document.PrinterSettings.MaximumPage = num;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    IPaper paper = new PaperClass();
                    paper.Attach(this._document.PrinterSettings.GetHdevmode(this._document.DefaultPageSettings).ToInt32(), this._document.PrinterSettings.GetHdevnames().ToInt32());
                    this._pageLayoutControl.Printer.Paper = paper;
                    IOutputRasterSettings displayTransformation = this._pageLayoutControl.ActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                    int resampleRatio = displayTransformation.ResampleRatio;
                    this.SetOutputQuality(this._pageLayoutControl.ActiveView, (long) resampleRatio);
                    bool flag = true;
                    try
                    {
                        this._document.Print();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("打印遇到问题：" + exception.Message);
                        flag = false;
                    }
                    if (flag)
                    {
                        MessageBox.Show("已打印完毕！");
                    }
                }
                dialog.Document.PrintPage -= new PrintPageEventHandler(this.Document_PrintPage);
            }
            catch (Exception exception2)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Print.ClsPrint", "Print", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
            }
        }

        private void SetOutputQuality(IActiveView docActiveView, long iResampleRatio)
        {
            try
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
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Print.ClsPrint", "SetOutputQuality", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public IActiveView ActiveView
        {
            set
            {
                this._activeView = value;
            }
        }

        public PrintDocument Document
        {
            set
            {
                this._document = value;
            }
        }

        public IPageLayoutControl PageLayoutControl
        {
            set
            {
                this._pageLayoutControl = value;
            }
        }
    }
}

