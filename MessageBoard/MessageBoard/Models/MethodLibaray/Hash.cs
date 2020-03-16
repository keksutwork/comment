using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MessageBoard.Models.MethodLibaray
{
    public static class Hash
    {
        public static string GetHashString(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            string res;
            using (SHA512 sha = new SHA512Managed())
            {
                res = sha.ComputeHash(bytes).ToString();
            }
            return res;
        }
    }
}