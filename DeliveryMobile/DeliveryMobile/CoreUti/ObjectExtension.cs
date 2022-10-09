using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.CoreUti
{
    public class ObjectExtension
    {
        public static T CloneByJson<T>(T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }

        public static bool EqualByJson(Object obj1, Object obj2)
        {
            return JsonConvert.SerializeObject(obj1) == JsonConvert.SerializeObject(obj2);
        }
    }
}
