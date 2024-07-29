using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZTool.Core.Util
{
    /// <summary>
    /// Json工具类
    /// </summary>
    public class JsonUtils
    {
        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="obj"> 对象 </param>
        /// <returns></returns>
        public static string ToJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="obj"> 对象 </param>
        /// <param name="settings"> 序列化配置 </param>
        /// <returns></returns>
        public static string ToJsonString(object obj, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"> json字符串 </param>
        /// <returns></returns>
        public static T ToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"> json字符串 </param>
        /// <param name="settings"> 序列化配置 </param>
        /// <returns></returns>
        public static T ToObject<T>(string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        /// <summary>
        /// 将Json字符串转换为Json对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject ParseObject(string json)
        {
            return JObject.Parse(json);
        }

        /// <summary>
        /// 将Json字符串转换为Json对象
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static JObject ParseObject(string json, JsonLoadSettings settings)
        {
            return JObject.Parse(json, settings);
        }

        /// <summary>
        /// 将Json字符串转换为Json数组
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JArray ParseArray(string json)
        {
            return JArray.Parse(json);
        }

        /// <summary>
        /// 将Json字符串转换为Json数组
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static JArray ParseArray(string json, JsonLoadSettings settings)
        {
            return JArray.Parse(json, settings);
        }

        /// <summary>
        /// 将Json字符串转换为Json属性
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JToken ParseProperty(string json)
        {
            return JProperty.Parse(json);
        }

        /// <summary>
        /// 将Json字符串转换为Json属性
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static JToken ParseProperty(string json, JsonLoadSettings settings)
        {
            return JProperty.Parse(json, settings);
        }

        /// <summary>
        /// 获取JsonToken的属性值
        /// </summary>
        /// <param name="jToken"> json对象 </param>
        /// <param name="key"> 属性key </param>
        /// <param name="defaultValue"> 默认值 </param>
        /// <returns></returns>
        public static T GetValue<T>(JToken jToken, string key, T defaultValue)
        {
            var jValue = jToken[key];
            if(jValue == null)
            {
                return defaultValue;
            }
            try
            {
                return jValue.ToObject<T>();
            }
            catch (Exception e)
            {
                LogUtils.Warn(typeof(JsonUtils), e.Message, e);
                return defaultValue;
            }
        }
    }
}
