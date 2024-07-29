using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 日期工具类
    /// </summary>
    public class DateUtils
    {
        /// <summary>
        /// Unix纪元（1970年1月1日）
        /// </summary>
        public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// 获取当前时区
        /// </summary>
        /// <returns></returns>
        public static TimeZoneInfo GetCurrentTimeZone()
        {
            return TimeZoneInfo.Local;
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 获取当前unix时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentUnixTimestamp()
        {
            return GetUnixTimestamp(GetCurrentDateTime());
        }

        /// <summary>
        /// 获取unix时间戳(毫秒)
        /// </summary>
        /// <param name="time"> 时间 </param>
        /// <returns></returns>
        public static long GetUnixTimestamp(DateTime time)
        {
            DateTime epoch = UNIX_EPOCH;
            TimeSpan span = time - epoch;
            return (long)span.TotalMilliseconds;
        }

        /// <summary>
        /// 根据unix时间戳获取时间
        /// </summary>
        /// <param name="unixTimestamp"> unix时间戳(毫秒) </param>
        /// <returns></returns>
        public static DateTime GetDateTime(long unixTimestamp)
        {
            DateTime epoch = UNIX_EPOCH;
            return epoch.AddSeconds(unixTimestamp);
        }
    }
}
