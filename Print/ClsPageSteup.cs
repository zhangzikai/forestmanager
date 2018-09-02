namespace Print
{
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Output;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing.Printing;
    using System.Globalization;
    using System.Windows.Forms;

    public class ClsPageSteup : IDisposable
    {
        private PrintDocument _document;
        private IPrinter _printer;
        private bool _success;
        private Component component = new Component();
        private bool disposed;

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

        public string PageStuep()
        {
            string message = "";
            try
            {
                PageSetupDialog dialog = new PageSetupDialog();
                dialog.ShowNetwork = false;
                dialog.AllowMargins = false;
                Margins margins = this._document.DefaultPageSettings.Margins;
                if (RegionInfo.CurrentRegion.IsMetric)
                {
                    this._document.DefaultPageSettings.Margins = PrinterUnitConvert.Convert(margins, PrinterUnit.Display, PrinterUnit.TenthsOfAMillimeter);
                }
                dialog.Document = this._document;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this._printer = new EmfPrinterClass();
                    string printerName = this._document.PrinterSettings.PrinterName;
                    if (!this._printer.DoesDriverSupportPrinter(printerName))
                    {
                        this._printer = null;
                        return "本系统不支持该打印机";
                    }
                    IEnumerator enumerator = dialog.PrinterSettings.PaperSizes.GetEnumerator();
                    enumerator.Reset();
                    bool flag = false;
                    for (int i = 0; i < dialog.PrinterSettings.PaperSizes.Count; i++)
                    {
                        enumerator.MoveNext();
                        if (((PaperSize) enumerator.Current).Kind == this._document.DefaultPageSettings.PaperSize.Kind)
                        {
                            flag = true;
                            this._document.DefaultPageSettings.PaperSize = (PaperSize) enumerator.Current;
                        }
                    }
                    if (!flag)
                    {
                        this._printer = null;
                        return "本系统不支持当前纸张类型";
                    }
                    IPaper paper = new PaperClass();
                    paper.Attach(this._document.PrinterSettings.GetHdevmode(this._document.DefaultPageSettings).ToInt32(), this._document.PrinterSettings.GetHdevnames().ToInt32());
                    this._printer.Paper = paper;
                    return message;
                }
                this._document.DefaultPageSettings.Margins = margins;
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            return message;
        }

        public PrintDocument Document
        {
            set
            {
                this._document = value;
            }
        }

        public IPrinter Printer
        {
            get
            {
                return this._printer;
            }
            set
            {
                this._printer = value;
            }
        }

        public bool Success
        {
            get
            {
                return this._success;
            }
        }
    }
}

