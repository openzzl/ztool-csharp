using log4net;
using System;

namespace ZTool.Core.Util
{
    /// <summary>
    /// 日志工具类
    /// </summary>
    public class LogUtils
    {
#if NET35
        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object syncRoot = new object();

        /// <summary>
        /// 日志管理器集合
        /// </summary>
        private static readonly System.Collections.Generic.Dictionary<string, ILog> _loggers = new System.Collections.Generic.Dictionary<string, ILog>();
#else
        /// <summary>
        /// 日志管理器集合
        /// </summary>
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, ILog> _loggers = new System.Collections.Concurrent.ConcurrentDictionary<string, ILog>();
#endif

        /// <summary>
        /// 获取日志记录器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ILog GetLogger(string name)
        {
#if NET35
            lock (syncRoot)
            {
                if (_loggers.ContainsKey(name))
                {
                    return _loggers[name];
                }
                else
                {
                    ILog logger = LogManager.GetLogger(name);
                    _loggers[name] = logger;
                    return logger;
                }
            }
#else
            return _loggers.GetOrAdd(name, tag => LogManager.GetLogger(tag));
#endif

        }

        #region Info

        /// <summary>
        /// 是否启用信息级别日志
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool IsInfoEnabled(string tag)
        {
            return GetLogger(tag).IsInfoEnabled;
        }

        /// <summary>
        /// 是否启用信息级别日志
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsInfoEnabled(Type type)
        {
            return GetLogger(type.FullName).IsInfoEnabled;
        }

        /// <summary>
        /// 输出信息日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Info(string tag, string message, Exception exception)
        {
            GetLogger(tag).Info(message, exception);
        }

        /// <summary>
        /// 输出信息日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Info(string tag, string format, object[] args)
        {
            GetLogger(tag).InfoFormat(format, args);
        }

        /// <summary>
        /// 输出信息日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Info(Type type, string message, Exception exception)
        {
            GetLogger(type.FullName).Info(message, exception);
        }

        /// <summary>
        /// 输出信息日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Info(Type type, string format, object[] args)
        {
            GetLogger(type.FullName).InfoFormat(format, args);
        }

        #endregion

        #region Debug

        /// <summary>
        /// 是否启用调试级别日志
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool IsDebugEnabled(string tag)
        {
            return GetLogger(tag).IsDebugEnabled;
        }

        /// <summary>
        /// 是否启用调试级别日志
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDebugEnabled(Type type)
        {
            return GetLogger(type.FullName).IsDebugEnabled;
        }

        /// <summary>
        /// 输出调试日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Debug(string tag, string message, Exception exception)
        {
            GetLogger(tag).Debug(message, exception);
        }

        /// <summary>
        /// 输出调试日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Debug(string tag, string format, object[] args)
        {
            GetLogger(tag).DebugFormat(format, args);
        }

        /// <summary>
        /// 输出调试日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Debug(Type type, string message, Exception exception)
        {
            GetLogger(type.FullName).Debug(message, exception);
        }

        /// <summary>
        /// 输出调试日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Debug(Type type, string format, object[] args)
        {
            GetLogger(type.FullName).DebugFormat(format, args);
        }

        #endregion

        #region Error

        /// <summary>
        /// 是否启用错误级别日志
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool IsErrorEnabled(string tag)
        {
            return GetLogger(tag).IsErrorEnabled;
        }

        /// <summary>
        /// 是否启用错误级别日志
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsErrorEnabled(Type type)
        {
            return GetLogger(type.FullName).IsErrorEnabled;
        }

        /// <summary>
        /// 输出错误日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Error(string tag, string message, Exception exception)
        {
            GetLogger(tag).Error(message, exception);
        }

        /// <summary>
        /// 输出错误日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Error(string tag, string format, object[] args)
        {
            GetLogger(tag).ErrorFormat(format, args);
        }

        /// <summary>
        /// 输出错误日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Error(Type type, string message, Exception exception)
        {
            GetLogger(type.FullName).Error(message, exception);
        }

        /// <summary>
        /// 输出错误日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Error(Type type, string format, object[] args)
        {
            GetLogger(type.FullName).ErrorFormat(format, args);
        }

        #endregion

        #region Warn

        /// <summary>
        /// 是否启用警告级别日志
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool IsWarnEnabled(string tag)
        {
            return GetLogger(tag).IsWarnEnabled;
        }

        /// <summary>
        /// 是否启用警告级别日志
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsWarnEnabled(Type type)
        {
            return GetLogger(type.FullName).IsWarnEnabled;
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Warn(string tag, string message, Exception exception)
        {
            GetLogger(tag).Warn(message, exception);
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Warn(string tag, string format, object[] args)
        {
            GetLogger(tag).WarnFormat(format, args);
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Warn(Type type, string message, Exception exception)
        {
            GetLogger(type.FullName).Warn(message, exception);
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Warn(Type type, string format, object[] args)
        {
            GetLogger(type.FullName).WarnFormat(format, args);
        }

        #endregion

        #region Fatal

        /// <summary>
        /// 是否启用致命级别日志
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool IsFatalEnabled(string tag)
        {
            return GetLogger(tag).IsFatalEnabled;
        }

        /// <summary>
        /// 是否启用致命级别日志
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsFatalEnabled(Type type)
        {
            return GetLogger(type.FullName).IsFatalEnabled;
        }

        /// <summary>
        /// 输出致命日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Fatal(string tag, string message, Exception exception)
        {
            GetLogger(tag).Fatal(message, exception);
        }

        /// <summary>
        /// 输出致命日志
        /// </summary>
        /// <param name="tag"> tag </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Fatal(string tag, string format, object[] args)
        {
            GetLogger(tag).FatalFormat(format, args);
        }

        /// <summary>
        /// 输出致命日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="message"> 日志消息 </param>
        /// <param name="exception"> 异常信息 </param>
        public static void Fatal(Type type, string message, Exception exception)
        {
            GetLogger(type.FullName).Fatal(message, exception);
        }

        /// <summary>
        /// 输出致命日志
        /// </summary>
        /// <param name="type"> 类型 </param>
        /// <param name="format"> 格式化日志 </param>
        /// <param name="args"> 消息参数 </param>
        public static void Fatal(Type type, string format, object[] args)
        {
            GetLogger(type.FullName).FatalFormat(format, args);
        }

        #endregion
    }
}
