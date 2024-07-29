using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 系统相关工具类
    /// </summary>
    public class SystemUtils
    {
        /// <summary>
        /// 获取操作系统版本
        /// </summary>
        /// <returns></returns>
        public static string GetOSVersion()
        {
            return Environment.OSVersion.ToString();
        }

        /// <summary>
        /// 获取操作系统版本名称
        /// </summary>
        /// <returns></returns>
        public static string GetOSVersionName()
        {
            return Environment.OSVersion.VersionString;
        }

        /// <summary>
        /// 获取计算机名称
        /// </summary>
        /// <returns></returns>
        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            return Environment.UserName;
        }

        /// <summary>
        /// 获取当前区域/语言
        /// </summary>
        /// <returns></returns>
        public static System.Globalization.CultureInfo GetCurrentCulture()
        {
            return System.Globalization.CultureInfo.CurrentCulture;
        }

#if NET6_0 || NET8_0
        /// <summary>
        /// 判断是否是Windows系统
        /// </summary>
        /// <returns></returns>
        public static bool IsWindows()
        {
            return System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
        }
#endif
    }
}
