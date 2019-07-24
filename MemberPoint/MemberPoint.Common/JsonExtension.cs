using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Common
{
    public static class JsonExtension
    {
        //1.将对象序列化成json字符串
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        //2.将字符串反序列化为对象
        public static T ToObject<T>(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            else
            {
                return default(T);
            }
        }
    }
}
