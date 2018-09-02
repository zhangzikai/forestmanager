namespace Print
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Output;
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using Utilities;

    public class ClsPrintView
    {
        private IActiveView _activeView;
        private PrintDocument _doc;
        private short _index;
        private IPageLayoutControl3 _pageLayoutControl;
        private PrintPreviewDialog _printPre;
        private const string mClassName = "Print.ClsPrintView";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        private void _doc_EndPrint(object sender, PrintEventArgs e)
        {
            if (!e.Cancel)
            {
                bool isValid = this._doc.DefaultPageSettings.PrinterSettings.IsValid;
            }
        }

        public void _doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                tagRECT grect;
                double num3;
                double num4;
                double num5;
                double num6;
                short num = this._pageLayoutControl.get_PrinterPageCount(MapPageSet.OverLap);
                this._doc.DocumentName = num.ToString();
                this._index = (short) (this._index + 1);
                short dpiX = (short) e.Graphics.DpiX;
                IEnvelope deviceBounds = new EnvelopeClass();
                IPage page = this._pageLayoutControl.PageLayout.Page;
                IPrinter printer = this._pageLayoutControl.Printer;
                page.GetDeviceBounds(printer, this._index, MapPageSet.OverLap, dpiX, deviceBounds);
                deviceBounds.QueryCoords(out num3, out num4, out num5, out num6);
                grect.bottom = (int) num6;
                grect.left = (int) num3;
                grect.top = (int) num4;
                grect.right = (int) num5;
                if ((grect.left != grect.right) && (grect.top != grect.bottom))
                {
                    IEnvelope pageBounds = new EnvelopeClass();
                    page.GetPageBounds(printer, this._index, MapPageSet.OverLap, pageBounds);
                    IntPtr hdc = e.Graphics.GetHdc();
                    this._pageLayoutControl.ActiveView.Output(hdc.ToInt32(), dpiX, ref grect, pageBounds, null);
                    e.Graphics.ReleaseHdc(hdc);
                }
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Print.ClsPrintView", "_doc_PrintPage", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void PreView()
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
                this._doc.PrintPage += new PrintPageEventHandler(this._doc_PrintPage);
                this._doc.EndPrint += new PrintEventHandler(this._doc_EndPrint);
                int x = (this._printPre.Owner.ClientSize.Width - this._printPre.Width) / 2;
                int y = (this._printPre.Owner.ClientSize.Height - this._printPre.Height) / 2;
                this._doc.DocumentName = this._pageLayoutControl.get_PrinterPageCount(MapPageSet.OverLap).ToString();
                this._printPre.PointToScreen(new System.Drawing.Point(x, y));
                this._printPre.SetDesktopLocation(x, y);
                this._printPre.SetDesktopLocation(x, y);
                this._printPre.Document = this._doc;
                this._printPre.UseAntiAlias = true;
                this._printPre.ShowDialog();
                this._doc.PrintPage -= new PrintPageEventHandler(this._doc_PrintPage);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Print.ClsPrintView", "PreView", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this._doc = value;
            }
        }

        public IPageLayoutControl3 PageLayoutControl
        {
            set
            {
                this._pageLayoutControl = value;
            }
        }

        public PrintPreviewDialog PrintPreViewWindow
        {
            get
            {
                if (this._printPre == null)
                {
                    this._printPre = new PrintPreviewDialog();
                }
                return this._printPre;
            }
        }
    }
}

