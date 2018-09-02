namespace ForestEarth
{
    using ForestEarth.EarthHelp;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public static class ClsConfigManage
    {
       

        public static bool ReadEarthService()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"EarthData\esconfig.xml";
            if (File.Exists(path))
            {
                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(path);
                    XmlNode node = document.SelectSingleNode("ESPATH");
                    if (node == null)
                    {
                        return false;
                    }
                    XmlNode node2 = node.SelectSingleNode("ESIP");
                    XmlNode node3 = node.SelectSingleNode("ESPORT");
                    XmlNode node4 = node.SelectSingleNode("ESNAME");
                    StringBuilder builder = new StringBuilder();
                    builder.Append("http://").Append(node2.InnerText).Append(":");
                    builder.Append(node3.InnerText).Append("/earth/scene=").Append(node4.InnerText);
                    PathEarthService = builder.ToString();
                    return true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("方法ReadEarthService读取三维服务地址配置文件信息出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            FrmServiceConfig config = new FrmServiceConfig();
            config.ShowDialog();
            config.Dispose();
            return config.CreateESConfigXml;
        }

        public static FrmInformation InformationForm
        {
            get;
            set;
        }

        public static string PathEarthService
        {
            get;
            set;
        }

        public static FrmIdentifyInfo XbInfoForm
        {
            get;
            set;
        }
    }
}

