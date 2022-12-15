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
            //creates new instance of md5 object
            
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //gets hash of string and stores as byte array 
            byte[] result = md5.Hash;

            StringBuilder password = new StringBuilder();
            for (int j = 0; j < result.Length; j++)
            {
                //changes to string in hexadecimal
                password.Append(result[j].ToString("x2"));
            }

            return password.ToString();
        }
    }
}

