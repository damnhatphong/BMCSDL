using System;
using System.Security.Cryptography;
using System.Text;

namespace Lap03_nhom.Encryptor
{
    public static class SHA1Encryptor
    {
        // Create a new instance of the MD5CryptoServiceProvider object.
        public static string getSHA1Hash(string input)
        {
            SHA1CryptoServiceProvider SHA1Hasher = new SHA1CryptoServiceProvider();
           
            byte[] data = SHA1Hasher.ComputeHash(Encoding.Unicode.GetBytes(input));

           
            StringBuilder sBuilder = new StringBuilder();
          
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2").ToUpper());
            }

            
            return sBuilder.ToString();
        }
    }
}
