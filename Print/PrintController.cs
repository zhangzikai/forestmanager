namespace Print
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Output;
    using PrintComponent;
    using System;
    using System.Drawing.Printing;
    using System.Globalization;

    /// <summary>
    /// 打印调节器
    /// </summary>
    public class PrintController
    {
        /// <summary>
        /// Windows:PrintDocument:定义从Windows窗体应用程序打印时将输出发送到打印机的可重用对象。
        /// </summary>
        public static System.Drawing.Printing.PrintDocument _pd;

        public static bool CheckPrintSet(System.Drawing.Printing.PrintDocument pPd, IPageLayoutControl3 pControl)
        {
            bool flag = true;
            flag = !pPd.PrinterSettings.DefaultPageSettings.Landscape || (pControl.Page.Orientation == 2);
            flag = pPd.PrinterSettings.DefaultPageSettings.Landscape || (pControl.Page.Orientation != 2);
            return (FormService.GetFormIdByName(pPd.PrinterSettings.DefaultPageSettings.PaperSize.PaperName) == pControl.Page.FormID);
        }

        /// <summary>
        /// 获取打印文档:定义纸张大小，并设置打印页面的参数：如间距，默认设置。
        /// </summary>
        /// <param name="pFormName"></param>
        /// <param name="pOrientation"></param>
        /// <returns></returns>
        private static System.Drawing.Printing.PrintDocument GetPrintDocument(string pFormName, short pOrientation)
        {
            PaperKind kind;
            if (pFormName == "A4")
            {
                kind = PaperKind.A4;
            }
            else
            {
                kind = PaperKind.A3;
            }
            System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
            foreach (PaperSize size in document.PrinterSettings.PaperSizes)
            {
                if (size.Kind == kind)
                {
                    document.PrinterSettings.DefaultPageSettings.PaperSize = size;
                    document.DefaultPageSettings.PaperSize = size;
                    if (pOrientation == 1)
                    {
                        document.PrinterSettings.DefaultPageSettings.Landscape = false;
                        document.DefaultPageSettings.Landscape = false;
                    }
                    else
                    {
                        document.PrinterSettings.DefaultPageSettings.Landscape = true;
                        document.DefaultPageSettings.Landscape = true;
                    }
                    break;
                }
            }
            Margins margins = document.DefaultPageSettings.Margins;
            if (RegionInfo.CurrentRegion.IsMetric)
            {
                document.DefaultPageSettings.Margins = PrinterUnitConvert.Convert(margins, PrinterUnit.Display, PrinterUnit.TenthsOfAMillimeter);
            }
            return document;
        }

        /// <summary>
        /// 设置默认的打印机。
        /// IPageLayoutControl接口是与PageLayoutControl相关的任何任务的起点，例如设置一般外观，设置页面和显示属性，添加和查找元素，加载地图文档和打印。
        /// IPageLayoutControl3接口为使用键盘和鼠标导航PageLayoutControl的显示相关任务提供了额外的成员。
        /// </summary>
        /// <param name="pFormName"></param>
        /// <param name="pOrientation"></param>
        /// <param name="pControl"></param>
        public static void SetDefaultPrintSet(string pFormName, short pOrientation, IPageLayoutControl3 pControl)
        {
            _pd = GetPrintDocument(pFormName, pOrientation);
            if (_pd.DefaultPageSettings.PrinterSettings.PrinterName != "未设置默认打印机。")
            {//ESRI:IPaper接口提供对控制默认打印机页面设置的成员的访问。纸张默认打印机页面设置。
                IPaper paper = new PaperClass();
                //IPaper.Attach方法将对象附加到指定的DEVMODE和DEVNAMES结构。在使用其他属性和方法之前必须先调用它。
                //打印机对象使用此方法，当设置IPrinter :: Paper属性时调用此方法。大多数ArcObjects开发人员不需要使用此方法，除非他们正在执行IPrinter的自定义实现。
                paper.Attach(_pd.PrinterSettings.GetHdevmode(_pd.DefaultPageSettings).ToInt32(), _pd.PrinterSettings.GetHdevnames().ToInt32());
                pControl.Printer.Paper = paper;
                //esriPageFormID常量表单支持页面。esriPageFormCUSTOM 12自定义页面大小。
                pControl.Page.FormID = esriPageFormID.esriPageFormCUSTOM;
                //IPage.Units属性用于页面和所有相关坐标的单位。
                pControl.Page.Units = pControl.Printer.Paper.Units;
                PrintInfoComponent.SafePrinterHandle.PrinterName = _pd.PrinterSettings.PrinterName;
                if (_pd.PrinterSettings.DefaultPageSettings.Landscape)
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

        public static void SetPaperFormAndOrientation(System.Drawing.Printing.PrintDocument pPd, string pFormName, short pOrientation)
        {
            if (pOrientation == 1)
            {
                pPd.PrinterSettings.DefaultPageSettings.Landscape = false;
                pPd.DefaultPageSettings.Landscape = false;
            }
            else
            {
                pPd.PrinterSettings.DefaultPageSettings.Landscape = true;
                pPd.DefaultPageSettings.Landscape = true;
            }
        }

        public static System.Drawing.Printing.PrintDocument PrintDocument
        {
            get
            {
                return _pd;
            }
            set
            {
                _pd = value;
            }
        }

        public static qSafePrinterHandle SH
        {
            get
            {
                return PrintInfoComponent.SafePrinterHandle;
            }
        }
    }
}

