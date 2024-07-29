using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public class StringUtils
    {
        /// <summary>
        /// 是否为空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 是否为非空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>000000000000000000000000000000
        public static bool IsNotEmpty(string str)
        {
            return !IsEmpty(str);
        }

        /// <summary>
        /// 去除首尾空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>
        public static string Trim(string str, params char[] trimChars)
        {
            return IsEmpty(str) ? string.Empty : str.Trim(trimChars);
        }

        /// <summary>
        /// 去除首空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>

        public static string TrimStart(string str, params char[] trimChars)
        {
            return IsEmpty(str) ? string.Empty : str.TrimStart(trimChars);
        }

        /// <summary>
        /// 去除尾空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>
        public static string TrimEnd(string str, params char[] trimChars)
        {
            return IsEmpty(str) ? string.Empty : str.TrimEnd(trimChars);
        }

        /// <summary>
        /// 获取换行字符串
        /// </summary>
        /// <returns></returns>
        public static string NewLine()
        {
            return Environment.NewLine;
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            return obj == null ? string.Empty : obj.ToString();
        }
    }
}
