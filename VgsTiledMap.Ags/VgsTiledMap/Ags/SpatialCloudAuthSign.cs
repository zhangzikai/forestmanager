namespace VgsTiledMap.Ags
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class SpatialCloudAuthSign
    {
        public static string GetMD5Hash(string z, string x, string y, string type, string login, string password)
        {
            string s = z + "/" + x + "/" + y + "." + type + login + password;
            byte[] buffer = MD5.Create().ComputeHash(Encoding.Default.GetBytes(s));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

