namespace Report
{
    using AttributesEdit;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Windows.Forms;

    internal class CF_Report_5 : ReportEntity
    {
        public CF_Report_5()
        {
            base.ReportID = "5";
            base.Theme = "CF";
        }

        public override void InitialReport(ReportParamter pReportParamter)
        {
            base.TaskID = pReportParamter.TaskID;
            base.SysType = pReportParamter.SysType;
            base.BK = pReportParamter.BK;
            base.ReportName = "简易伐区调查设计表";
            base.DataTable = pReportParamter.DataTable;
        }

        public override string Static(Workbook pWorkbook)
        {
            AttriEdit.ExportToHarExcel(base.DataTable, base.BK, pWorkbook);
            pWorkbook.Saved = true;
            pWorkbook.Save();
            System.Windows.Forms.Application.DoEvents();
            return null;
        }
    }
}

