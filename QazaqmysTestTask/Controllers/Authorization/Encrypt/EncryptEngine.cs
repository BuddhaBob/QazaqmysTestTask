using System.Security.Cryptography;

namespace QazaqmysTestTask.Controllers.Authorization.Encrypt
{
    public class EncryptEngine
    {
        public static string GetMD5Hash(string input)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
                bytes = md5.ComputeHash(bytes);
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

                foreach (var b in bytes)
                {

                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
