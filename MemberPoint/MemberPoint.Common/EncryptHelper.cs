using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Common
{
    public class EncryptHelper
    {
        public static string GetMd5Hash(string str)
        {
            using (MD5 md5Obj = MD5.Create())
            {
                var md5Bytes = md5Obj.ComputeHash(Encoding.UTF8.GetBytes(str));
                //md5Obj.Dispose();
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < md5Bytes.Length; i++)
                {

                    builder.Append(md5Bytes[i].ToString("X2"));//3500元
                }
                return builder.ToString();
            }
        }
    }
}
