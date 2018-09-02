namespace Report
{
    using DevExpress.XtraEditors;
    using System;
    using System.Windows.Forms;
    using td.forest.report;

    /// <summary>
    /// 各种报表条目类
    /// </summary>
    public class ReportEntry
    {
        /// <summary>
        /// 显示报表的方法
        /// </summary>
        /// <param name="pReportParamter"></param>
        public void Show(ReportParamter pReportParamter)
        {
           if (pReportParamter.TaskName == "小班统计")//“二维浏览”的“输出报表”窗体在此触发
            {
                frmSelectTable fst = new frmSelectTable(pReportParamter.FindFromLayer_XB);
                fst.ShowDialog();
                return;
            }

            if (pReportParamter.TaskName != "火灾")
            {
                if (pReportParamter.SysType == SystemType.FQSJ)
                {
                    pReportParamter.Theme = StatisticsTheme.CF;
                    FQReportStatic @static = new FQReportStatic(pReportParamter);
                    if (@static.Init())
                    {
                        @static.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("报表初始化没有成功，不能进行统计！");
                    }
                    @static.Dispose();
                    @static = null;
                }
                else
                {
                    string taskName = pReportParamter.TaskName;
                    if (taskName != null)
                    {
                        switch (taskName)
                        {
                            case "采伐":
                            {
                                pReportParamter.Theme = StatisticsTheme.CF;
                                ReportStatic static2 = new ReportStatic(pReportParamter);
                                if (static2.Init())
                                {
                                    static2.ShowDialog();
                                }
                                else
                                {
                                    XtraMessageBox.Show("报表初始化没有成功，不能进行统计！");
                                }
                                static2.Dispose();
                                static2 = null;
                                return;
                            }
                            case "林业案件":
                            {
                                pReportParamter.Theme = StatisticsTheme.AJ;
                                AJZHReportStatic static3 = new AJZHReportStatic(pReportParamter);
                                if (static3.Init())
                                {
                                    static3.ShowDialog();
                                }
                                else
                                {
                                    XtraMessageBox.Show("报表初始化没有成功，不能进行统计！");
                                }
                                static3.Dispose();
                                static3 = null;
                                return;
                            }
                        }
                        if (taskName == "自然灾害")
                        {
                            pReportParamter.Theme = StatisticsTheme.ZH;
                            AJZHReportStatic static4 = new AJZHReportStatic(pReportParamter);
                            if (static4.Init())
                            {
                                static4.ShowDialog();
                            }
                            else
                            {
                                XtraMessageBox.Show("报表初始化没有成功，不能进行统计！");
                            }
                            static4.Dispose();
                            static4 = null;
                        }
                    }
                }
            }
          
            else
            {
                SfReportStatic static5 = new SfReportStatic(pReportParamter);
                if (static5.Init())
                {
                    static5.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("报表初始化没有成功，不能进行统计！");
                }
                static5.Dispose();
                static5 = null;
            }
        }

        public void ShowPTFQDJRegister(ReportParamter pReportParamter)
        {
            try
            {
                ReportViewer viewer = new ReportViewer(pReportParamter.Theme);
                StaticMsg msg = new StaticMsg {
                    StartMessage = "正在查询...",
                    Title = "登记表查询",
                    ExceptionMessage = "查询遇到异常！",
                    Verb = "正在查询：",
                    StaticReportCount = pReportParamter.IDs.Count
                };
                pReportParamter.StatisticsMsg = msg;
                viewer.Static(pReportParamter,null);
            }
            catch (Exception)
            {
            }
        }
        public void ShowRegister(ReportParamter pReportParamter)
        {
            try
            {
                ReportViewer viewer = new ReportViewer(pReportParamter.Theme);
                if (pReportParamter.SysType == SystemType.FQSJ)
                {
                    FQDJReportStatic @static = new FQDJReportStatic(pReportParamter.FeatureLayer, pReportParamter.TaskID);
                    if (@static.ShowDialog() == DialogResult.OK)
                    {
                        pReportParamter.BK = @static.GetTj();
                        @static = null;
                    }
                    else
                    {
                        @static = null;
                        return;
                    }
                }
                StaticMsg msg = new StaticMsg {
                    StartMessage = "正在查询...",
                    Title = "登记表查询",
                    ExceptionMessage = "查询遇到异常！",
                    Verb = "正在查询：",
                    StaticReportCount = pReportParamter.IDs.Count
                };
                pReportParamter.StatisticsMsg = msg;
                viewer.Static(pReportParamter,null);
            }
            catch (Exception)
            {
            }
        }
    }
}

