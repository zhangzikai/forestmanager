namespace Report
{
    using System;
    using System.Runtime.InteropServices;
    using Utilities;

    /// <summary>
    /// 统计信息类
    /// </summary>
    internal class StatisticsInfo
    {
        private StatisticsTheme _themeInfo;

        /// <summary>
        /// 统计信息类：构造器：参数（统计主题）
        /// </summary>
        /// <param name="pTheme"></param>
        public StatisticsInfo(StatisticsTheme pTheme)
        {
            this._themeInfo = pTheme;
        }

        /// <summary>
        /// 获取统计的Excel样本路径和保存路径。参数（获取Excel路径，保存Excel路径）
        /// </summary>
        /// <param name="pTemplatePath"></param>
        /// <param name="pSavePath"></param>
        public void GetTemplatePath(out string pTemplatePath, string pSavePath)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Concat(new object[] { DateTime.Now.ToLongDateString(), DateTime.Now.Hour, "时", DateTime.Now.Minute, "分", DateTime.Now.Second, "秒" });
            switch (this._themeInfo)
            {
                case StatisticsTheme.CF:
                    str = "report.xls";
                    str2 = "report_" + str3 + ".xls";
                    break;

                case StatisticsTheme.SF:
                    str = "sfreport.xls";
                    str2 = "sfreport_" + str3 + ".xls";
                    break;

                case StatisticsTheme.ZH:
                    str = "bchreport.xls";
                    str2 = "bchreport" + str3 + ".xls";
                    break;

                case StatisticsTheme.AJ:
                    str = "ajreport.xls";
                    str2 = "ajreport" + str3 + ".xls";
                    break;
            }
            string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("report", "reportpath");
            int startIndex = AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("bin");
            str4 = AppDomain.CurrentDomain.BaseDirectory.Remove(startIndex) + str4;
            pTemplatePath = str4 + str;
            string str5 = UtilFactory.GetConfigOpt().GetConfigValue2("report", "reportstaticpath");
            startIndex = AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("bin");
            str5 = AppDomain.CurrentDomain.BaseDirectory.Remove(startIndex) + str5;
            pSavePath = str5 + str2;
        }
    }
}

