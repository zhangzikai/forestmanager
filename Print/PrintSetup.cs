namespace Print
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Output;
    using System;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public sealed class PrintSetup
    {
        public void ShowDialog(PrintDocument pPd, IPageLayoutControl3 pControl)
        {
            PrintDialog dialog = new PrintDialog();
            dialog.Document = pPd;
            dialog.PrinterSettings = pPd.PrinterSettings;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Print.PrintController.SH.PrinterName = dialog.PrinterSettings.PrinterName;
                Print.PrintController.PrintDocument = dialog.Document;
                IPaper paper = new PaperClass();
                paper.Attach(pPd.PrinterSettings.GetHdevmode(pPd.DefaultPageSettings).ToInt32(), pPd.PrinterSettings.GetHdevnames().ToInt32());
                pControl.Printer.Paper = paper;
                if (pControl.Page.FormID == esriPageFormID.esriPageFormSameAsPrinter)
                {
                    if (Print.PrintController.PrintDocument.PrinterSettings.DefaultPageSettings.Landscape)
                    {
                        pControl.Page.Orientation = 2;
                    }
                    else
                    {
                        pControl.Page.Orientation = 1;
                    }
                    double width = pControl.Printer.Paper.PrintableBounds.Width;
                    double height = pControl.Printer.Paper.PrintableBounds.Height;
                    pControl.Page.PutCustomSize(width, height);
                    pControl.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
                }
            }
        }
    }
}

