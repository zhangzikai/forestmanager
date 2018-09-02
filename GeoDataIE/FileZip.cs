namespace GeoDataIE
{
    using ICSharpCode.SharpZipLib.Checksums;
    using ICSharpCode.SharpZipLib.Zip;
    using System;
    using System.Collections;
    using System.IO;

    public class FileZip
    {
        public static bool CopyDirectory(string srcdir, string desdir)
        {
            try
            {
                string str = srcdir.Substring(srcdir.LastIndexOf(@"\") + 1);
                string str2 = desdir;
                if (desdir.LastIndexOf(@"\") == (desdir.Length - 1))
                {
                    str2 = desdir + str;
                }
                foreach (string str3 in Directory.GetFileSystemEntries(srcdir))
                {
                    if (Directory.Exists(str3))
                    {
                        string path = str2 + @"\" + str3.Substring(str3.LastIndexOf(@"\") + 1);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        CopyDirectory(str3, str2);
                    }
                    else
                    {
                        string destFileName = str3.Substring(str3.LastIndexOf(@"\") + 1);
                        destFileName = str2 + @"\" + destFileName;
                        if (!Directory.Exists(str2))
                        {
                            Directory.CreateDirectory(str2);
                        }
                        File.Copy(str3, destFileName);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void DeleteFolder(string dir)
        {
            foreach (string str in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(str))
                {
                    FileInfo info = new FileInfo(str);
                    if (info.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        info.Attributes = FileAttributes.Normal;
                    }
                    File.Delete(str);
                }
                else
                {
                    DeleteFolder(str);
                }
            }
            Directory.Delete(dir);
        }

        public static void DeleteFolderFile(string dir)
        {
            try
            {
                foreach (string str in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(str))
                    {
                        FileInfo info = new FileInfo(str);
                        if (info.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        {
                            info.Attributes = FileAttributes.Normal;
                        }
                        File.Delete(str);
                    }
                    else
                    {
                        DeleteFolder(str);
                    }
                }
            }
            catch
            {
            }
        }

        public static string UnzipFile(string sSourceFileName)
        {
            try
            {
                ZipEntry entry;
                string path = sSourceFileName.Substring(0, sSourceFileName.Length - 4);
                ZipInputStream stream = new ZipInputStream(File.OpenRead(sSourceFileName));
                new ArrayList();
                bool flag = true;
                while ((entry = stream.GetNextEntry()) != null)
                {
                    try
                    {
                        string fileName = Path.GetFileName(entry.Name);
                        if (fileName == "")
                        {
                            continue;
                        }
                        fileName = path + @"\" + fileName;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        FileStream stream2 = File.Create(fileName);
                        int count = 0x800;
                        byte[] buffer = new byte[0x800];
                        stream.Password = "land1234";
                        while (true)
                        {
                            count = stream.Read(buffer, 0, buffer.Length);
                            if (count <= 0)
                            {
                                break;
                            }
                            stream2.Write(buffer, 0, count);
                        }
                        stream2.Close();
                        continue;
                    }
                    catch
                    {
                        flag = false;
                        break;
                    }
                }
                stream.Close();
                if (!flag)
                {
                    DeleteFolder(path);
                    return "";
                }
                return path;
            }
            catch
            {
                return "";
            }
        }

        public static string ZipFile(string sPath)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(sPath);
                if (!info.Exists)
                {
                    return "";
                }
                string path = info.FullName + ".zip";
                Crc32 crc = new Crc32();
                ZipOutputStream stream = new ZipOutputStream(File.Create(path));
                stream.Password = "land1234";
                stream.SetLevel(6);
                FileInfo[] files = info.GetFiles();
                bool flag = true;
                foreach (FileInfo info2 in files)
                {
                    try
                    {
                        if (!info2.FullName.Contains("timestamps"))
                        {
                            FileStream stream2 = File.OpenRead(info2.FullName);
                            byte[] buffer = new byte[stream2.Length];
                            stream2.Read(buffer, 0, buffer.Length);
                            ZipEntry entry = new ZipEntry(info2.FullName);
                            entry.DateTime = DateTime.Now;
                            entry.Size = stream2.Length;
                            stream2.Close();
                            crc.Reset();
                            crc.Update(buffer);
                            entry.Crc = crc.Value;
                            stream.PutNextEntry(entry);
                            stream.Write(buffer, 0, buffer.Length);
                        }
                    }
                    catch
                    {
                        flag = false;
                        break;
                    }
                }
                stream.Finish();
                stream.Close();
                if (!flag)
                {
                    File.Delete(path);
                    return "";
                }
                return path;
            }
            catch
            {
                return "";
            }
        }
    }
}

