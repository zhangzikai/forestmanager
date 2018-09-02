namespace GXFormStart
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS;
    using OperateLog;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using Utilities;
    using jn.isos.log;
    using td.gis.fun;
    using ESRI.ArcGIS.esriSystem;
    using td.gis.forest;
    using td.db.orm.mssql;

    internal static class Program
    {
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            XtraMessageBox.Show(e.Exception.Source + "-" + e.Exception.GetHashCode().ToString(), "系统遇到问题！");
        }
        private static Logger s_log;
        [STAThread]
        private static void Main()
        {
            LoggerManager.LoggerInitDynamic("Forest");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            s_log = LoggerManager.CreateLogger("UI", typeof(Program));
            s_log.Warn("系统启动...");
            s_log.Warn("验证ArcGIS许可...");
            if (!InitLincense())
            {
                XtraMessageBox.Show("ArcGIS许可未正常启动！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            InitGISForm ilf = new InitGISForm();
            s_log.Warn("读取配置...");

            ErrorOpt errorOpt = UtilFactory.GetErrorOpt();
            string sSystemName = "森林资源管理信息平台";
            string sClassName = "GXFormStart.Program";
            try
            {
                FormLogin4 login2;
                RuntimeManager.Bind(ProductCode.EngineOrDesktop);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");

                Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
                VgsTileMapCache.SetCachePath();
                if (UtilFactory.GetConfigOpt2().GetConfigValue2("DataBase", "DBKey") != "SqlServer")
                {
                    goto Label_0123;
                }
                string str4 = UtilFactory.GetConfigOpt2().GetConfigValue2("DataBase", "Initial");
            Label_008A:
                if (str4 == "0")
                {
                    FormDataBaseLogin login = new FormDataBaseLogin();
                    login.ShowDialog();
                    login.Dispose();
                }
                //以下也许是源代码有错
            ////TDMSSqlDBConnection.Single.Init("Data\LocalDB.mdb");
                ////if (dBAccess == null)
                ////{
                ////    if (DialogResult.OK != XtraMessageBox.Show("数据库连接遇到问题，请确保网络连接和配置参数设置正确！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                ////    {
                ////        Application.Exit();
                ////        return;
                ////    }
                ////    str4 = "0";
                ////    goto Label_008A;
                ////}
                ////DBAccessBase base2 = dBAccess as DBAccessBase;
                ////if (!base2.TestConnection())
                ////{
                ////    if (DialogResult.OK != XtraMessageBox.Show("数据库连接遇到问题，请重新设置配置参数！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                ////    {
                ////        Application.Exit();
                ////        return;
                ////    }
                ////    str4 = "0";
                ////    goto Label_008A;
                ////}
            Label_0123:
                login2 = new FormLogin4();
                string fileName = Application.StartupPath + @"\GXFormStart.exe";
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(fileName);
                login2.labelV.Text = "版本V" + versionInfo.ProductVersion;
                login2.labelV.Text = login2.labelV.Text + "\r\n发布日期" + File.GetLastWriteTime(fileName).ToString("yyyyMMdd");
                new FileInfo(fileName);
                Application.Run(login2);
            }
            catch (Exception exception)
            {
                errorOpt.ErrorOperate(sSystemName, sClassName, "Main", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                XtraMessageBox.Show(exception.Source + "-" + exception.GetHashCode().ToString(), "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private static LicenseInitializer m_AOLicenseInitializer;
        private static bool InitLincense()
        {

            s_log.Warn("LicenseInitializer");
            m_AOLicenseInitializer = new LicenseInitializer();
            bool flag = false;
            s_log.Warn("Bind(ProductCode.Engine)");
            if (RuntimeManager.Bind(ProductCode.Engine))
            {
                flag = true;
                //   IAoInitialize aoLiceseInitialize = new AoInitializeClass();
                //esriLicenseStatus st=   aoLiceseInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeEngineGeoDB);
                //  if (m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] {  esriLicenseProductCode.esriLicenseProductCodeEngineGeoDB }, new esriLicenseExtensionCode[0]))
                if (m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine }, new esriLicenseExtensionCode[0]))
                {
                    return true;
                }
            }
            s_log.Warn("Bind(ProductCode.Desktop)");
            if (RuntimeManager.Bind(ProductCode.Desktop))
            {
                flag = true;
                if (m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeAdvanced }, new esriLicenseExtensionCode[0]))
                {
                    return true;
                }
            }
            if (!flag)
            {
                MessageBox.Show("ArcGIS Runtime 或 ArcMap未安装，GIS功能不可用！");
            }
            else
            {
                MessageBox.Show(m_AOLicenseInitializer.LicenseMessage() + "\n\n应用程序缺少ARCGIS授权，GIS功能不可用");
                m_AOLicenseInitializer.ShutdownApplication();
            }
            return false;
        }
    }
}

