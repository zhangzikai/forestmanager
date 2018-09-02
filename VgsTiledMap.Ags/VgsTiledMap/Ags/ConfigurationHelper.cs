namespace VgsTiledMap.Ags
{
    using System;
    using System.Configuration;
    using System.Reflection;

    public class ConfigurationHelper
    {
        public static System.Configuration.Configuration GetConfig()
        {
            System.Configuration.Configuration configuration = null;
            string str = Assembly.GetExecutingAssembly().Location + ".config";
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            try
            {
                fileMap.ExeConfigFilename = str;
                configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            catch
            {
                throw new ApplicationException(string.Format("Can not find ({0})", str));
            }
            return configuration;
        }

        public static string GetVgsConfigFile()
        {
            return (Assembly.GetExecutingAssembly().Location + ".config");
        }
    }
}

