namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Framework;
    using System;
    using System.IO;
    using System.Reflection;

    internal static class Util
    {
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2.0) + Math.Pow(y1 - y2, 2.0));
        }

        public static string GetAppDir()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().GetModules()[0].FullyQualifiedName);
        }

        public static void SetVgsTiledMapPropertyPage(IApplication application, VgsArcTileLayer layer)
        {
        }

        public static string AppName
        {
            get
            {
                return Assembly.GetEntryAssembly().GetName().Name.ToString();
            }
        }

        public static string DefaultCacheDir
        {
            get
            {
                return @"c:\TileCache";
            }
        }
    }
}

