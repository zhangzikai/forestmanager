namespace VgsTiledMap.Ags
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Xml;

    public class TmsTileMapServiceParser
    {
        public static List<TileMap> GetTileMaps(string Url)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14");
            IWebProxy systemWebProxy = WebRequest.GetSystemWebProxy();
            systemWebProxy.Credentials = CredentialCache.DefaultCredentials;
            client.Proxy = systemWebProxy;
            byte[] bytes = client.DownloadData(Url);
            string xml = Encoding.UTF8.GetString(bytes);
            client.Dispose();
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlNodeList elementsByTagName = document.GetElementsByTagName("TileMap");
            List<TileMap> list2 = new List<TileMap>();
            foreach (XmlNode node in elementsByTagName)
            {
                TileMap map2 = new TileMap();
                map2.Href = node.Attributes["href"].Value;
                map2.Srs = node.Attributes["srs"].Value;
                map2.Profile = node.Attributes["profile"].Value;
                map2.Title = node.Attributes["title"].Value;
                TileMap item = map2;
                if (node.Attributes["type"] != null)
                {
                    item.Type = node.Attributes["type"].Value;
                }
                if (node.Attributes["overwriteurls"] != null)
                {
                    item.OverwriteUrls = bool.Parse(node.Attributes["overwriteurls"].Value);
                }
                list2.Add(item);
            }
            return list2;
        }
    }
}

