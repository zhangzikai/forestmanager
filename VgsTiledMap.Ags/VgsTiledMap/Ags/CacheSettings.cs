namespace VgsTiledMap.Ags
{
    using System;
    using System.IO;

    public static class CacheSettings
    {
        public static string GetCacheFolder()
        {
            string path = ConfigurationHelper.GetConfig().AppSettings.Settings["tileDir"].Value;
            if (path.Contains("%"))
            {
                path = ReplaceEnvironmentVar(path);
            }
            return path;
        }

        public static string GetServicesConfigDir()
        {
            string path = ConfigurationHelper.GetConfig().AppSettings.Settings["servicesConfigDir"].Value;
            if (path.Contains("%"))
            {
                path = ReplaceEnvironmentVar(path);
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static int GetTileTimeOut()
        {
            return int.Parse(ConfigurationHelper.GetConfig().AppSettings.Settings["tileTimeout"].Value);
        }

        public static string ReplaceEnvironmentVar(string path)
        {
            int index = path.IndexOf("%");
            int num2 = path.LastIndexOf("%");
            string variable = path.Substring(index + 1, (num2 - index) - 1);
            string environmentVariable = Environment.GetEnvironmentVariable(variable);
            path = path.Replace("%" + variable + "%", environmentVariable);
            return path;
        }
    }
}

