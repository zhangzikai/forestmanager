namespace StatisChart
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    using Utilities;

    public static class ClassUtils
    {
        private static string m_key = "abcdefgh";
        public static string TABLE_ADMIN = "";
        public static string TABLE_CODE = "";

        public static bool CreateDbConfigXml()
        {
            return true;
        }

        public static string Decrypt(string pToDecrypt)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] buffer = new byte[pToDecrypt.Length / 2];
                for (int i = 0; i < (pToDecrypt.Length / 2); i++)
                {
                    int num2 = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte) num2;
                }
                provider.Key = Encoding.ASCII.GetBytes(m_key);
                provider.IV = Encoding.ASCII.GetBytes(m_key);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.Default.GetString(stream.ToArray());
            }
            catch
            {
                return "";
            }
        }

        public static string Encrypt(string pToEncrypt)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
                provider.Key = Encoding.ASCII.GetBytes(m_key);
                provider.IV = Encoding.ASCII.GetBytes(m_key);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }
                return builder.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return "";
            }
        }

        public static bool ReadDbConfigXml()
        {
            return true;
        }

        public static bool TestSqlServerConnection()
        {
            try
            {
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("数据库连接失败，可能的原因：" + exception.Message);
                return false;
            }
        }
    }
}

