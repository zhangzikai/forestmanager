namespace GX_DBUpdate.vUtils
{
    using System;
    using System.Collections;
    using System.IO;

    public static class vPathUtil
    {
        public static ArrayList GetUQLFiles()
        {
            FileInfo[] files = new DirectoryInfo(GetUQLPath()).GetFiles();
            string str = ".UQL,.SQL";
            ArrayList list = new ArrayList();
            foreach (FileInfo info2 in files)
            {
                if (!string.IsNullOrEmpty(info2.Extension) && (str.IndexOf(info2.Extension.ToUpper()) >= 0))
                {
                    list.Add(info2);
                }
            }
            return list;
        }

        public static string GetUQLPath()
        {
            string location = typeof(vPathUtil).Assembly.Location;
            DirectoryInfo info = new DirectoryInfo(location);
            location = location.Replace(info.Name, "") + "UQL" + Path.DirectorySeparatorChar;
            DirectoryInfo info2 = new DirectoryInfo(location);
            if (!info2.Exists)
            {
                Directory.CreateDirectory(location);
            }
            return location;
        }

        public static ArrayList GetVersionDirs()
        {
            DirectoryInfo[] directories = new DirectoryInfo(GetUQLPath()).GetDirectories();
            ArrayList list = new ArrayList();
            foreach (DirectoryInfo info2 in directories)
            {
                if (!string.IsNullOrEmpty(info2.Name) && info2.Name.Contains("TO"))
                {
                    string str = info2.Name.ToUpper();
                    string str2 = str.Substring(0, str.IndexOf("TO"));
                    string str3 = str.Substring(str.IndexOf("TO") + "TO".Length);
                    if (!string.IsNullOrEmpty(str2) && !string.IsNullOrEmpty(str3))
                    {
                        list.Add(info2);
                    }
                }
            }
            return list;
        }

        public static FileInfo GetVersionFile(string vFileName)
        {
            ArrayList uQLFiles = GetUQLFiles();
            if ((uQLFiles != null) && (uQLFiles.Count > 0))
            {
                FileInfo[] files = new DirectoryInfo(GetUQLPath()).GetFiles();
                string str = ".UQL,.SQL";
                foreach (FileInfo info2 in files)
                {
                    if ((!string.IsNullOrEmpty(info2.Extension) && (str.IndexOf(info2.Extension.ToUpper()) >= 0)) && (info2.Name.Replace(info2.Extension, "").ToUpper().CompareTo(vFileName.ToUpper()) == 0))
                    {
                        files = null;
                        return info2;
                    }
                }
            }
            return null;
        }

        public static ArrayList GetVersionFiles(DirectoryInfo dirInfo)
        {
            string str = ".UQL,.SQL";
            FileInfo[] files = dirInfo.GetFiles();
            ArrayList list = new ArrayList();
            foreach (FileInfo info in files)
            {
                if (!string.IsNullOrEmpty(info.Extension) && (str.IndexOf(info.Extension.ToUpper()) >= 0))
                {
                    list.Add(info);
                }
            }
            return list;
        }
    }
}

