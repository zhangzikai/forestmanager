namespace Report
{
    using System;

    /// <summary>
    /// 报表的工厂类
    /// </summary>
    internal class ReportFactory
    {
        /// <summary>
        /// 获取统计报表的各个表单
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pTheme"></param>
        /// <returns></returns>
        public static ReportEntity GetReportEntity(string pID, StatisticsTheme pTheme)
        {
            return (Activator.CreateInstance(Type.GetType("Report." + pTheme.ToString() + "_Report_" + pID)) as ReportEntity);
        }
    }
}

