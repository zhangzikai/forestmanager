using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GXFormMainFrame
{
    public class SQLServerConString
    {

        public static string Get_M_Str_ConnectionString()
        {
            string M_Str_ConnectionString = null; ;
            DirectoryInfo parentDirectory = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            parentDirectory = GetParentDirectory(parentDirectory, "Config");
            if (parentDirectory != null)
            {
                string filename = parentDirectory.FullName + @"\Config\AppConfig.xml";
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                //连接SQlite数据库
                ////XmlNode node = document.SelectSingleNode("//DataBase//SQLite");
                //连接SQLServer数据库
                XmlNode node = document.SelectSingleNode("//DataBase//SqlServer");

                if (node.HasChildNodes)
                {
                    XmlNodeList childNodes = node.ChildNodes;
                    string[] strArray = new string[childNodes.Count];
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        strArray[i] = childNodes.Item(i).InnerText;
                    }
                    M_Str_ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
                }
            }
            return M_Str_ConnectionString;
        }

        private static DirectoryInfo GetParentDirectory(DirectoryInfo directoryInfo_0, string name)
        {
            try
            {
                if (directoryInfo_0.Parent.GetDirectories(name).Length > 0)
                {
                    return directoryInfo_0.Parent;
                }
                return GetParentDirectory(directoryInfo_0.Parent, name);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "获取Config目录错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }
    }
}
