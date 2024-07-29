using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Result
{
    /// <summary>
    /// ajax返回结果
    /// </summary>
    public class AjaxResult : Hashtable, IResult
    {
        /** 状态码 */
        public static readonly string CODE_TAG = "code";

        /** 返回消息 */
        public static readonly string MSG_TAG = "msg";

        /** 数据对象 */
        public static readonly string DATA_TAG = "data";

        /// <summary>
        /// 构造方法
        /// </summary>
        public AjaxResult()
        {
            this.Set(R.FAIL, "操作失败");
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 返回消息 </param>
        public AjaxResult(int code, string msg)
        {
            this.Set(code, msg);
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        public AjaxResult(int code, string msg, object data)
        {
            this.Set(code, msg, data);
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public AjaxResult Set(int code, string msg)
        {
            this[CODE_TAG] = code;
            this[MSG_TAG] = msg;
            return this;
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <returns></returns>
        public AjaxResult Set(int code, string msg, object data)
        {
            this[CODE_TAG] = code;
            this[MSG_TAG] = msg;
            this[DATA_TAG] = data;
            return this;
        }

        /// <summary>
        /// 设置成功结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <returns></returns>
        public AjaxResult SetOk(string msg, object data)
        {
            return this.Set(R.SUCCESS, msg, data);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public AjaxResult SetFail(string msg)
        {
            return this.Set(R.FAIL, msg);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <returns></returns>
        public AjaxResult SetFail(string msg, object data)
        {
            return this.Set(R.FAIL, msg, data);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public AjaxResult SetWarn(string msg)
        {
            return this.Set(R.WARN, msg);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <returns></returns>
        public AjaxResult SetWarn(string msg, object data)
        {
            return this.Set(R.WARN, msg, data);
        }

        /// <summary>
        /// 是否为成功结果
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess()
        {
            object code = this[CODE_TAG];
            return code != null && (int)code == R.SUCCESS;
        }

        /// <summary>
        /// 是否为错误结果
        /// </summary>
        /// <returns></returns>
        public bool IsError()
        {
            object code = this[CODE_TAG];
            return code != null && (int)code == R.FAIL;
        }

        /// <summary>
        /// 设置成功结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <returns></returns>
        public static AjaxResult Ok(string msg, object data)
        {
            return new AjaxResult().SetOk(msg, data);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public static AjaxResult Fail(string msg)
        {
            return new AjaxResult().SetFail(msg);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <returns></returns>
        public static AjaxResult Fail(string msg, object data)
        {
            return new AjaxResult().SetFail(msg, data);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public static AjaxResult Warn(string msg)
        {
            return new AjaxResult().SetWarn(msg);
        }

        /// <summary>
        /// 设置警告结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <returns></returns>
        public static AjaxResult Warn(string msg, object data)
        {
            return new AjaxResult().SetWarn(msg, data);
        }

        /// <summary>
        /// 是否为成功结果
        /// </summary>
        /// <param name="ajaxResult">ajax返回结果</param>
        /// <returns></returns>
        public static bool IsSuccess(AjaxResult ajaxResult)
        {
            return ajaxResult != null && ajaxResult.IsSuccess();
        }

        /// <summary>
        /// 是否为错误结果
        /// </summary>
        /// <param name="ajaxResult"> ajax返回结果 </param>
        /// <returns></returns>
        public static bool IsError(AjaxResult ajaxResult)
        {
            return ajaxResult != null && ajaxResult.IsError();
        }
    }
}
