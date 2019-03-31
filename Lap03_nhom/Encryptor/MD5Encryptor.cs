using System;
using System.Security.Cryptography;
using System.Text;

namespace Lap03_nhom.Encryptor
{
    public static class MD5Encryptor
    {
        public static string getMd5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            
            byte[] data = md5Hasher.ComputeHash(Encoding.Unicode.GetBytes(input));
            
            StringBuilder sBuilder = new StringBuilder();
           
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2").ToUpper());
            }                        
            return sBuilder.ToString();
        }
    }
}
