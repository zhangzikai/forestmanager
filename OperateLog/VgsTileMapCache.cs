namespace OperateLog
{
    using System;
    using System.Configuration;
    using System.IO;
    using Utilities;

    /// <summary>
    /// 
    /// </summary>
    public class VgsTileMapCache
    {
        public static void DeleteCache()
        {
            try
            {
                string path = ConfigurationManager.OpenExeConfiguration(UtilFactory.GetConfigOpt().RootPath + @"\bin\VgsTiledMap.Ags.dll").AppSettings.Settings["tileDir"].Value.ToString();
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设置缓存路径
        /// </summary>
        public static void SetCachePath()
        {
            try
            {
                string rootPath = UtilFactory.GetConfigOpt().RootPath;
                //以下源代码有误：
                //Configuration:提供对客户端应用程序配置文件的访问。 此类不能被继承。
                //ConfigurationManager.OpenExeConfiguration 方法 (String)将指定的客户端配置文件作为 Configuration 对象打开。
                System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(rootPath + @"Debug\VgsTiledMap.Ags.dll");
                string path = rootPath + @"Debug\VgsTileMapCache";
                configuration.AppSettings.Settings["tileDir"].Value = path;
                configuration.Save();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch
            {
                Console.WriteLine("未能成功加载配置文件！！！");
            }
        }
    }
}

