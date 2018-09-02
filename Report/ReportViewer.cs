namespace Report
{
    using DevExpress.XtraEditors;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using td.db.mid.sys;
    using td.db.orm;
    using td.logic.sys;
    using Utilities;

    /// <summary>
    /// 报表视图类：主要将数据写入Excel表格中
    /// </summary>
    internal class ReportViewer
    {
        private const string _mClassName = "Report.ReportViewer";
        private string _mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private volatile bool _stopWaitDialog;
        private StatisticsTheme _theme;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private StaticMsg msg;
        private string reportPath;
        private string reportSavePath;
        private Thread st;
        private bool success = true;

        /// <summary>
        /// 报表视图类：构造器：主要将数据写入Excel表格中.
        /// </summary>
        /// <param name="pTheme"></param>
        public ReportViewer(StatisticsTheme pTheme)
        {
            this._theme = pTheme;
        }

        /// <summary>
        /// 写出到Excel表格中
        /// </summary>
        /// <param name="pParameter"></param>
        public void ExportExcel(ReportParamter pParameter)
        {
            Thread thread = null;
            this.msg = pParameter.StatisticsMsg;
            try
            {
                thread = new Thread(new ThreadStart(this.showWait));
                thread.Start();
                while (!thread.IsAlive)
                {
                    Thread.Sleep(1);
                }
                //使用多线程执行查询数据写入Excel表格的操作
                this.st = new Thread(new ParameterizedThreadStart(this.StaticExcute));
                this.st.Start(pParameter);
                this.st.Join();
            }
            catch (Exception)
            {
                this.success = false;
            }
            finally
            {
                if (thread != null)
                {
                    this._stopWaitDialog = true;
                    thread.Join();
                    this._stopWaitDialog = false;
                }
                ExcelAccess.KillExcelEx();
                if ((this.msg.ThreadMsg == 1) || this.success)
                {
                    XtraMessageBox.Show(this.msg.EndMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    XtraMessageBox.Show(this.msg.ExceptionMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        /// <summary>
        /// 获取Excel的报表名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetReportNameExcel()
        {
            List<string> list = new List<string>();
            string str = UtilFactory.GetConfigOpt().GetConfigValue2("report", "reportpath");
            int startIndex = AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("bin");
            System.Data.DataTable excelTableName = new ExcelAccess(AppDomain.CurrentDomain.BaseDirectory.Remove(startIndex) + str, true).GetExcelTableName();
            if (excelTableName != null)
            {
                foreach (DataRow row in excelTableName.Rows)
                {
                    string item = row[2].ToString().Trim(new char[] { '$' });
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过sql查询遍历的方式获取报表名称：将报表名称添加进List中
        /// </summary>
        /// <param name="pNames"></param>
        /// <param name="pIds"></param>
        public void GetReportNameSql(ref List<string> pNames, ref List<string> pIds)
        {       
            foreach (T_STAT_REPORT_Mid mid in MDM.FindReport(this._theme.ToString()))
                {
                    string item = mid.ReportName;
                    pNames.Add(item);
                    item = mid.ReportID.ToString();
                    pIds.Add(item);
                }
            
        }
        private MetaDataManager MDM
        { get { return DBServiceFactory<MetaDataManager>.Service; } }
        private void showWait()
        {
            try
            {
                new WaitDialog(new WaitDialog.CheckStopWaitDialog(this.StopWaitDialog), this.st, this.msg).ShowDialog();
            }
            catch (Exception)
            {
                this.success = false;
            }
        }

        /// <summary>
        /// 开启多线程，将数据写入Excel报表
        /// </summary>
        /// <param name="pParameter"></param>
        public void Static(ReportParamter pParameter,string path)
        {
            Thread thread = null;
            this.msg = pParameter.StatisticsMsg;
            try
            {
                thread = new Thread(new ThreadStart(this.showWait));
                thread.Start();
                while (!thread.IsAlive)
                {
                    Thread.Sleep(1);
                }
				if(path!=null&&path!="")
                	pParameter.ExportPath = path;

                this.st = new Thread(new ParameterizedThreadStart(this.StaticExcute));
                this.st.Start(pParameter);
                this.st.Join();
            }
            catch (Exception)
            {
                this.success = false;
            }
            finally
            {
                if (thread != null)
                {
                    this._stopWaitDialog = true;
                    thread.Join();
                    this._stopWaitDialog = false;
                }
               
                ExcelAccess.KillExcelEx();
                if (this.msg.ThreadMsg == 1)
                {
                    XtraMessageBox.Show(this.msg.EndMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (this.success)
                {
                    new StatisticsInfo(pParameter.Theme);
                    new Process { StartInfo = { 
                        FileName = this.reportSavePath,
                        Verb = "Open",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Normal
                    } }.Start();
                }
                else
                {
                    XtraMessageBox.Show(this.msg.ExceptionMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }


        /// <summary>
        /// 静态执行的方法：执行将查询数据写入Excel表格的操作的方法。
        /// </summary>
        /// <param name="pReportParameter"></param>
        private void StaticExcute(object pReportParameter)
        {
            try
            {
                ReportParamter pReportParamter = pReportParameter as ReportParamter;
                List<string> iDs = pReportParamter.IDs;
                List<string> names = pReportParamter.Names;
                if (iDs != null)
                {
                    new StatisticsInfo(pReportParamter.Theme).GetTemplatePath(out this.reportPath, this.reportSavePath);
                    

                    if (!string.IsNullOrEmpty(pReportParamter.ExportPath))
                    {
                        this.reportSavePath = pReportParamter.ExportPath;

                    }
                    //SaveFileDialog dialog = new SaveFileDialog();
                    //dialog.Title = "保存火灾登记表";
                    //dialog.DefaultExt = ".xls";
                    //dialog.Filter = "Excel电子表(*.xls)|*.xls";
                    //if (dialog.ShowDialog() != DialogResult.OK)
                    //{
                    //    return;
                    //}
                    //reportSavePath = dialog.FileName;
                    //reportSavePath = @"C:\abc.xls";

                    File.Copy(this.reportPath, this.reportSavePath, true);
                    Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                    Workbook pWorkbook = application.Workbooks.Open(this.reportSavePath, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
                    application.DisplayAlerts = false;
                    string str = null;
                    //删除不用的sheet
                    for (int i = pWorkbook.Sheets.Count; i >= 1; i--)
                    {
                        Worksheet worksheet = pWorkbook.Sheets[i] as Worksheet;
                        if (!names.Contains(worksheet.Name))
                        {
                            worksheet.Delete();
                        }
                    }
                    foreach (string str2 in iDs)
                    {
                        ReportEntity reportEntity = ReportFactory.GetReportEntity(str2, pReportParamter.Theme);
                        if (reportEntity != null)
                        {
                            //真正获取数据
                            reportEntity.InitialReport(pReportParamter);
                            this.msg.Start = true;
                            this.msg.TableInfo = this.msg.Verb + reportEntity.ReportName;
                            //将数据写入到Excel
                            str = str + reportEntity.Static(pWorkbook) + Environment.NewLine;
                        }
                    }
                    pWorkbook.Save();
                    if (!string.IsNullOrEmpty(str.Trim()))
                    {
                        int startIndex = str.LastIndexOf(',');
                        if (startIndex != -1)
                        {
                            str = str.Remove(startIndex, 1);
                        }
                        XtraMessageBox.Show("报表：" + Environment.NewLine + str + Environment.NewLine + "没有数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    if (application != null)
                    {
                        application.Workbooks.Close();
                        application.Quit();
                        int generation = GC.GetGeneration(application);
                        Marshal.ReleaseComObject(application);
                        application = null;
                        GC.Collect(generation);
                    }
                    GC.Collect();
                    ExcelAccess.KillExcelEx();
                }
            }
            catch (Exception exception)
            {
                this.success = false;
                this.mErrOpt.ErrorOperate(this._mSubSysName, "Report.ReportViewer", "StaticExcute", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public bool StopWaitDialog()
        {
            return this._stopWaitDialog;
        }
    }
}

