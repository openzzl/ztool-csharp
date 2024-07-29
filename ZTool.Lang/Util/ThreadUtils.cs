using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 线程工具类
    /// </summary>
    public class ThreadUtils
    {
        /// <summary>
        /// 线程延迟
        /// </summary>
        /// <param name="millisecondsTimeout"></param>
        public static void Sleep(int millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout);
        }

        /// <summary>
        /// 线程延迟
        /// </summary>
        /// <param name="timeout"> 超时时间 </param>
        public static void Sleep(TimeSpan timeout)
        {
            Thread.Sleep(timeout);
        }

        /// <summary>
        /// 获取当前线程
        /// </summary>
        /// <returns></returns>
        public static Thread GetCurrentThread()
        {
            return Thread.CurrentThread;
        }

        /// <summary>
        /// 获取当前线程ID
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
