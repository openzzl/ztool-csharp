using System;

namespace ZTool.Lang.Result
{
    /// <summary>
    /// 响应信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class R<T> : IResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int SUCCESS = 200;

        /// <summary>
        /// 失败
        /// </summary>
        public const int FAIL = 500;

        /// <summary>
        /// 警告
        /// </summary>
        public const int WARN = 601;

        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Msg { get; private set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public R()
        {
            this.Set(FAIL, "操作失败");
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 响应消息 </param>
        public R(int code, string msg)
        {
            this.Set(code, msg);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据 </param>
        public R(int code, string msg, T data)
        {
            this.Set(code, msg, data);
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 响应消息 </param>
        /// <returns></returns>
        public R<T> Set(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
            return this;
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据</param>
        /// <returns></returns>
        public R<T> Set(int code, string msg, T data)
        {
            this.Code = code;
            this.Msg = msg;
            this.Data = data;
            return this;
        }

        /// <summary>
        /// 设置成功结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据 </param>
        /// <returns></returns>
        public R<T> SetOk(string msg, T data)
        {
            return this.Set(R.SUCCESS, msg, data);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <returns></returns>
        public R<T> SetFail(string msg)
        {
            return this.Set(R.FAIL, msg);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据 </param>
        /// <returns></returns>
        public R<T> SetFail(string msg, T data)
        {
            return this.Set(R.FAIL, msg, data);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <returns></returns>
        public R<T> SetWarn(string msg)
        {
            return this.Set(R.WARN, msg);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据 </param>
        /// <returns></returns>
        public R<T> SetWarn(string msg, T data)
        {
            return this.Set(R.WARN, msg, data);
        }

        /// <summary>
        /// 是否为成功结果
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess()
        {
            return this.Code == SUCCESS;
        }

        /// <summary>
        /// 是否为错误结果
        /// </summary>
        /// <returns></returns>
        public bool IsError()
        {
            return this.Code != FAIL;
        }
    }

    /// <summary>
    /// 响应信息
    /// </summary>
    public class R : R<object>
    {
        /// <summary>
        /// 设置成功结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据 </param>
        /// <returns></returns>
        public static R<T> Ok<T>(string msg, T data)
        {
            return new R<T>().SetOk(msg, data);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <returns></returns>
        public static R<T> Fail<T>(string msg)
        {
            return new R<T>().SetFail(msg);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据 </param>
        /// <returns></returns>
        public static R<T> Fail<T>(string msg, T data)
        {
            return new R<T>().SetFail(msg, data);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <returns></returns>
        public static R<T> Warn<T>(string msg)
        {
            return new R<T>().SetWarn(msg);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 响应消息 </param>
        /// <param name="data"> 响应数据 </param>
        /// <returns></returns>
        public static R<T> Warn<T>(string msg, T data)
        {
            return new R<T>().SetWarn(msg, data);
        }

        /// <summary>
        /// 是否为成功结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r"> 响应信息 </param>
        /// <returns></returns>
        public static bool IsSuccess<T>(R<T> r)
        {
            return r != null && r.IsSuccess();
        }

        /// <summary>
        /// 是否为错误结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r"> 响应信息 </param>
        /// <returns></returns>
        public static bool IsError<T>(R<T> r)
        {
            return r != null && r.IsError();
        }
    }
}
