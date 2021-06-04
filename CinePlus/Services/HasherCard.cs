using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CinePlus.Services
{
    public static class HasherCard
    {
        public static string Hash(string line)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] messageBytes;
            messageBytes = encoding.GetBytes(line);
            var shHash = SHA256.Create();
            return shHash.ComputeHash(messageBytes).ToString();
        }
    }
}
