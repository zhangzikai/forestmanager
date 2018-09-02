namespace GXFormMainFrame
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS;
    using ForestEarth;
    using OperateLog;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Security.Principal;
    using System.Threading;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using jn.isos.log;
    using ESRI.ArcGIS.esriSystem;
    using td.gis.fun;
    using td.gis.forest;
    using td.db.orm.mssql;
    using td.db.service.factory;
    using td.db.orm.sqlite;
    using System.Data.SQLite;

    internal static class Program
    {
        /// <summary>
        /// 项目多线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ErrorOpt errorOpt = UtilFactory.GetErrorOpt();
            string systemName = UtilFactory.GetConfigOpt().GetSystemName();
            string sClassName = "DataAcquisition.Program";
            errorOpt.ErrorOperate(systemName, sClassName, "Application_ThreadException", e.Exception.GetHashCode().ToString(), e.Exception.Source, e.Exception.Message, "", "", "");
        }



        private static Logger s_log;
        [STAThread]
        private static void Main(string[] args)
        {
            //区别是会动态产生新的目录,从而可以区分一个程序启动多个进程的情况.
            LoggerManager.LoggerInitDynamic("Forest");
            s_log = LoggerManager.CreateLogger("UI", typeof(Program));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            s_log.Warn("系统启动...");
            s_log.Warn("验证ArcGIS许可...");
            if (!InitLincense())
            {
                XtraMessageBox.Show("ArcGIS许可未正常启动！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            //初始化GIS窗体:源代码被注销
            //InitGISForm ilf = new InitGISForm();
            //ilf.ShowDialog();
            s_log.Warn("读取配置...");
            UtilFactory.GetConfigOpt().RootPath = Application.StartupPath;
            ErrorOpt errorOpt = UtilFactory.GetErrorOpt();
            string systemName = UtilFactory.GetConfigOpt().GetSystemName();
            string sClassName = "GXFormMainFrame.Program";
            try
            {

                if (args.Length != 0)
                {
                    StartByCommand(args);
                }

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
                Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
                VgsTileMapCache.SetCachePath();

                #region 访问MSSqlServer
                ////string connStr = "Data Source=localhost;Initial Catalog=FORDATA_142326_2016;User Id=sa;Password=sa123456;";
                ///string connStr = "Data Source=114.215.140.122;Initial Catalog=sde;User Id=sde;Password=sde;";
                string connStr = SQLServerConString.Get_M_Str_ConnectionString();
                TDMSSqlDBConnection.Single.Init(connStr);
                DBServiceFactory.Single.DBType = "MSSqlServer";
                #endregion

                #region 访问sqlite
                ////TDDBConnection.Single.Init(UtilFactory.GetConfigOpt().RootPath + "Data\\forest_142326_2016.db");
                ////string sqlitepath = UtilFactory.GetConfigOpt().RootPath + "Data\\forest_142326_2016.db";
                ////DBServiceFactory.Single.DBType = "Sqlite";
                //<DBKey Name="Access or Oracle or SqlServer">Sqlite</DBKey>
                #endregion

                string sDBKey = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey");

                #region 连接SQLServer
                if (sDBKey == "SqlServer")
                {
                    s_log.Warn("读取配置完毕.");
                    StartDirectly(sDBKey);//此时传入StartDirectly（）方法的参数是sDBKey=“Sqlite”
                    goto Label_End;//APP退出
                }
                #endregion

                #region 此处连接的是SQLite数据库，这是可选的。是与配置文件匹配的
                ////if (sDBKey == "Sqlite")
                ////{
                ////    s_log.Warn("读取配置完毕.");
                ////    StartDirectly(sDBKey);//此时传入StartDirectly（）方法的参数是sDBKey=“Sqlite”
                ////    goto Label_End;//APP退出
                ////}
                #endregion
                string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "Initial");
                s_log.Warn("读取配置完毕.");
            Label_00B1:
                if (str4 == "0")
                {
                    FormDataBaseLogin login = new FormDataBaseLogin();
                    login.ShowDialog();
                    login.Dispose();
                }
                s_log.Warn("连接数据库...");

                if (TDMSSqlDBConnection.Single.IsOpen() == false)
                {
                    if (DialogResult.OK != XtraMessageBox.Show("数据库连接遇到问题，请确保网络连接和配置参数设置正确！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        Application.Exit();
                        return;
                    }
                    str4 = "0";
                    goto Label_00B1;
                }

                if (TDMSSqlDBConnection.Single.IsOpen() == false)
                {
                    if (DialogResult.OK != XtraMessageBox.Show("数据库连接遇到问题，请重新设置配置参数！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        Application.Exit();
                        return;
                    }
                    str4 = "0";
                    goto Label_00B1;
                }

                s_log.Warn("开始启动:" + sDBKey);
                StartDirectly(sDBKey);
            Label_End://APP退出
                Application.Exit();
            }
            catch (Exception exception)
            {
                errorOpt.ErrorOperate(systemName, sClassName, "Main", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 通过editKind的值，选择开始启动哪个窗体
        /// </summary>
        /// <param name="sDBKey"></param>
        private static void StartDirectly(string sDBKey)
        {

            FormLogin4 login2;
            string editKind;//封装传递进来的字符串，通过此字符串判断打开那个窗体
            string str7;
            MainFrameEdit edit;
            string[] strArray;
            MainFrameQuery query;
            string configValue;
            WindowsIdentity current;
            WindowsPrincipal principal;
            MainFrameSystem system;
            FrmEarth earth;
            //  IDBAccess dBAccess;
            s_log.Warn("开始登录.");
            login2 = new FormLogin4();//初始化登录窗体，将在此窗体中实现选择哪个子窗体登录
            string fileName = Application.StartupPath + @"\GXFormMainFrame.exe";//定义启动GXFormMainFrame.exe文件
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(fileName);
            login2.labelV.Text = "版本V" + versionInfo.ProductVersion;
            login2.labelV.Text = login2.labelV.Text + "\r\n发布日期" + File.GetLastWriteTime(fileName).ToString("yyyyMMdd");
            FileInfo info2 = new FileInfo(fileName);
            login2.ShowDialog();
            if (login2.CancelFlag)
            {
                login2.Close();
                Application.Exit();
            }
            else
            {
                editKind = login2.EditKind;
                login2.panelLogin.Visible = false;//FormLogin4的“登录面板”隐藏
                login2.panelProgress.Visible = true;//FormLogin4的登录的“进度面板”显示
                login2.Show();
                Application.DoEvents();
                if (login2.CancelFlag)
                {
                    login2.Close();
                    Application.Exit();
                }
                else
                {
                    editKind = login2.EditKind;
                    str7 = editKind;
                    //返回一个值，该值指示指定的 System.String 对象是否出现在此字符串中。
                    if (str7.Contains("Edit") || str7.Contains("编辑"))
                    {//“业务管理系统”--“造林”、“采伐”、“征占用”、“火灾”、“案件”、“灾害”窗体在此触发
                        //“年度更新系统”---“遥感编辑”、“变更编辑”、“年度编辑”、“林场变更”窗体也在此触发
                        login2.Show();
                        login2.SetLoadInfo("正在设置系统界面...", 10);
                        Application.DoEvents();

                        edit = new MainFrameEdit();
                        strArray = editKind.Split(new char[] { '-' });
                        edit.mEditKind = strArray[0];
                        edit.FormSplash = login2;
                        edit.WindowState = FormWindowState.Minimized;
                        if (!edit.InitializeForm())
                        {
                            login2.Close();
                            Application.Exit();
                        }
                        else
                        {
                            edit.WindowState = FormWindowState.Maximized;
                            edit.Show();
                            login2.panelProgress.Visible = false;
                            login2.SetLoadInfo("", 0);
                            login2.m_Timer.Stop();
                            login2.Close();
                            login2 = null;
                            Application.Run(edit);
                            edit.Dispose();
                            edit = null;
                        }
                    }

                    else if (((str7 == "Query") || str7.Contains("查询统计")) || str7.Contains("二维浏览"))
                    { //“信息管理系统”--“二维浏览”窗体在此初始化
                        login2.Show();
                        login2.SetLoadInfo("正在设置系统界面...", 10);
                        Application.DoEvents();
                        query = new MainFrameQuery();//初始化“资源信息查询”的“二维浏览”窗体
                        strArray = editKind.Split(new char[] { '-' });//此处将"年度小班-二维浏览"分割为“年度小班”
                        query.mEditKind = strArray[0];
                        query.FormSplash = login2;
                        if (!query.InitializeForm())
                        {
                            login2.Close();
                            Application.Exit();
                        }
                        else
                        {
                            login2.panelProgress.Visible = false;
                            login2.m_Timer.Stop();
                            login2.Close();
                            login2 = null;
                            Application.Run(query);
                        }
                    }
                    else if (str7.Contains("三维"))
                    { //“信息管理系统”--“三维浏览”窗体在此初始化
                        //   configValue = UtilFactory.GetConfigOpt().GetConfigValue("EditYear");
                        ////   dBAccess = UtilFactory.GetDBAccess(sDBKey);
                        //   TaskManageClass.InitialEditValues("年度小班", configValue, null);
                        //   if (ClsConfigManage.ReadEarthService())
                        //   {
                        //       earth = new FrmEarth(dBAccess.ConnectionString, configValue);
                        //       login2.panelProgress.Visible = false;
                        //       login2.m_Timer.Stop();
                        //       login2.Close();
                        //       login2 = null;
                        //       Application.Run(earth);
                        //   }
                        //   else
                        //   {
                        //       login2.Show();
                        //   }
                    }
                    else if (str7.Contains("System") || str7.Contains("系统管理"))
                    {//“系统管理“系统在此触发
                        current = WindowsIdentity.GetCurrent();
                        Application.EnableVisualStyles();
                        principal = new WindowsPrincipal(current);
                        if (true)
                            //if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            Application.EnableVisualStyles();
                            strArray = editKind.Split(new char[] { '-' });
                            login2.Show();
                            login2.SetLoadInfo("正在设置系统界面...", 10);
                            Application.DoEvents();
                            system = new MainFrameSystem
                            {
                                mEditKind = "年度小班",
                                FormSplash = login2
                            };
                            if (!system.InitializeForm())
                            {
                                login2.Close();
                                Application.Exit();
                            }
                            else
                            {
                                login2.panelProgress.Visible = false;
                                login2.m_Timer.Stop();
                                login2.Close();
                                login2 = null;
                                Application.Run(system);
                            }
                        }
                        else
                        {
                            MessageBox.Show("当前启动用户不是管理员，不能进入系统管理模块，请退出系统以管理员身份运行，或选择其它子系统。", "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 通过命令开始启动，判断启动那个窗体
        /// </summary>
        /// <param name="args"></param>
        private static void StartByCommand(string[] args)
        {
            string sDBKey;
            //编辑方式
            string editKind;
            string str7;
            //编辑窗体
            MainFrameEdit edit;
            string[] strArray;
            //查询窗体
            MainFrameQuery query;
            string configValue;

            FrmEarth earth;
            WindowsIdentity current;
            WindowsPrincipal principal;
            //系统管理窗体
            MainFrameSystem system;
            //   IDBAccess dBAccess;
            RuntimeManager.Bind(ProductCode.EngineOrDesktop);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
            Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
            editKind = args[0];
            str7 = editKind;
            FormLogin6 login3 = new FormLogin6
            {
                panelProgress = { Visible = true }
            };
            login3.Show();
            if (str7.Contains("Edit") || str7.Contains("编辑"))
            {
                login3.Show();
                login3.SetLoadInfo("正在设置系统界面...", 20);
                Application.DoEvents();
                edit = new MainFrameEdit
                {
                    FormSplash6 = login3
                };
                strArray = editKind.Split(new char[] { '-' });
                edit.mEditKind = strArray[0];
                edit.WindowState = FormWindowState.Minimized;
                if (!edit.InitializeForm())
                {
                    login3.Close();
                    MessageBox.Show("窗体初始化失败", "登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                else
                {
                    edit.WindowState = FormWindowState.Maximized;
                    edit.Show();
                    login3.panelProgress.Visible = false;
                    login3.SetLoadInfo("", 0);
                    login3.m_Timer.Stop();
                    login3.Close();
                    login3 = null;
                    Application.Run(edit);
                    edit.Dispose();
                    edit = null;
                }
            }
            else if (((str7 == "Query") || str7.Contains("查询统计")) || str7.Contains("二维浏览"))
            {
                login3.Show();
                login3.SetLoadInfo("正在设置系统界面...", 20);
                Application.DoEvents();
                query = new MainFrameQuery
                {
                    FormSplash6 = login3
                };
                strArray = editKind.Split(new char[] { '-' });
                query.mEditKind = strArray[0];
                if (!query.InitializeForm())
                {
                    login3.Close();
                    MessageBox.Show("窗体初始化失败", "登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                else
                {
                    login3.panelProgress.Visible = false;
                    login3.SetLoadInfo("", 0);
                    login3.m_Timer.Stop();
                    login3.Close();
                    login3 = null;
                    Application.Run(query);
                    query.Dispose();
                    query = null;
                }
            }
            else if (str7.Contains("三维"))
            {
                login3.Show();
                login3.SetLoadInfo("正在设置系统参数...", 10);
                Application.DoEvents();
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("EditYear");
                login3.SetLoadInfo("正在设置系统参数...", 20);
                sDBKey = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey");
                login3.SetLoadInfo("正在设置系统参数...", 30);
                //   dBAccess = UtilFactory.GetDBAccess(sDBKey);
                TaskManageClass.InitialEditValues("年度小班", configValue, null);
                if (EditTask.EditWorkspace == null)
                {
                    MessageBox.Show("窗体初始化失败", "登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    login3.Close();
                }
                else
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("EditYear");
                    login3.SetLoadInfo("正在设置系统参数...", 40);
                    if (ClsConfigManage.ReadEarthService())
                    {
                        login3.SetLoadInfo("正在设置系统界面...", 50);
                        //earth = new FrmEarth(dBAccess.ConnectionString, configValue);
                        //login3.SetLoadInfo("正在设置系统界面...", 90);
                        //login3.panelProgress.Visible = false;
                        //login3.SetLoadInfo("", 0);
                        //login3.m_Timer.Stop();
                        //login3.Close();
                        //login3 = null;
                        //Application.Run(earth);
                    }
                    else
                    {
                        MessageBox.Show("读取三维服务失败，请确认服务是否正常启动。", "登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        login3.Close();
                    }
                }
            }
            else if (str7.Contains("System") || str7.Contains("系统管理"))
            {
                current = WindowsIdentity.GetCurrent();
                Application.EnableVisualStyles();
                principal = new WindowsPrincipal(current);
                if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    Application.EnableVisualStyles();
                    strArray = editKind.Split(new char[] { '-' });
                    Application.DoEvents();
                    login3.Show();
                    login3.SetLoadInfo("正在设置系统界面...", 20);
                    Application.DoEvents();
                    system = new MainFrameSystem
                    {
                        FormSplash6 = login3,
                        mEditKind = "年度小班"
                    };
                    if (!system.InitializeForm())
                    {
                        login3.Close();
                        MessageBox.Show("窗体初始化失败");
                        Application.Exit();
                    }
                    else
                    {
                        login3.panelProgress.Visible = false;
                        login3.SetLoadInfo("", 0);
                        login3.m_Timer.Stop();
                        login3.Close();
                        login3 = null;
                        Application.Run(system);
                        system.Dispose();
                        system = null;
                    }
                }
                else
                {
                    MessageBox.Show("当前启动用户不是管理员，不能进入系统管理模块，请退出系统以管理员身份运行，或选择其它子系统。", "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static LicenseInitializer m_AOLicenseInitializer;


        /// <summary>
        /// 初始化监听。将在此监听中确定绑定何种产品，并该产品是否已经获得许可。
        /// </summary>
        /// <returns></returns>
        private static bool InitLincense()
        {
            s_log.Warn("LicenseInitializer");
            m_AOLicenseInitializer = new LicenseInitializer();
            bool flag = false;
            s_log.Warn("Bind(ProductCode.Engine)");
            //初始化许可：如果产品为Desktop
            if (RuntimeManager.Bind(ProductCode.Desktop))
            {
                flag = true;                 //为项目初始化许可
                if (m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngineGeoDB }, new esriLicenseExtensionCode[0]))
                {
                    return true;
                }
            }
            s_log.Warn("Bind(ProductCode.Desktop)");
            //初始化许可：如果产品为Engine
            if (RuntimeManager.Bind(ProductCode.Engine))
            {
                flag = true;
                //
                if (m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngineGeoDB }, new esriLicenseExtensionCode[0]))
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

