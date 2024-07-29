using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 进程工具类
    /// </summary>
    public class ProcessUtils
    {
        /// <summary>
        /// 获取当前进程信息
        /// </summary>
        /// <returns></returns>
        public static Process GetCurrentProcess()
        {
            return Process.GetCurrentProcess();
        }

        /// <summary>
        /// 获取当前进程ID
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentProcessId()
        {
            return Process.GetCurrentProcess().Id;
        }

        /// <summary>
        /// 获取进程集合
        /// </summary>
        /// <returns></returns>
        public static Process[] GetProcesses()
        {
            return Process.GetProcesses();
        }

        /// <summary>
        /// 根据进程ID获取进程信息
        /// </summary>
        /// <param name="processId"> 进程ID </param>
        /// <returns></returns>
        public static Process GetProcessById(int processId)
        {
            return Process.GetProcessById(processId);
        }
    }
}
