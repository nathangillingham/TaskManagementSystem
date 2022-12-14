using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NEADatabase
{
    public static class Encryptor
    {
        public static string Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder password = new StringBuilder();
            for (int j = 0; j < result.Length; j++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                password.Append(result[j].ToString("x2"));
            }

            return password.ToString();
        }
    }
}

