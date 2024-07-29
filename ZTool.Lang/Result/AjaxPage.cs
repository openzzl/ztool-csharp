using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZTool.Lang.Result
{
    /// <summary>
    /// ajax 分页结果
    /// </summary>
    public class AjaxPage : Hashtable, IResult
    {
        /** 状态码 */
        public static readonly string CODE_TAG = "code";

        /** 返回消息 */
        public static readonly string MSG_TAG = "msg";

        /** 列表数据 */
        public static readonly string ROWS_TAG = "rows";

        /** 总记录数 */
        public static readonly string TOTAL_TAG = "data";

        /// <summary>
        /// 构造方法
        /// </summary>
        public AjaxPage()
        {
            this.Set(R.FAIL, "操作失败");
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 返回消息 </param>
        public AjaxPage(int code, string msg)
        {
            this.Set(code, msg);
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="rows"> 数据对象 </param>
        /// <param name="total"> 总记录数 </param>
        public AjaxPage(object rows, int total)
        {
            this.Set(R.SUCCESS, "操作成功");
            this.Set(rows, total);
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="code"> 状态码 </param>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public AjaxPage Set(int code, string msg)
        {
            this[CODE_TAG] = code;
            this[MSG_TAG] = msg;
            return this;
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="rows"> 数据对象 </param>
        /// <param name="total"> 总记录数 </param>
        /// <returns></returns>
        public AjaxPage Set(object rows, int total)
        {
            this[ROWS_TAG] = rows;
            this[TOTAL_TAG] = total;
            return this;
        }

        /// <summary>
        /// 设置成功结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <param name="total"> 总记录数 </param>
        /// <returns></returns>
        public AjaxPage SetOk(string msg, object data, int total)
        {
            this.Set(R.SUCCESS, msg);
            return this.Set(data, total);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public AjaxPage SetFail(string msg)
        {
            return this.Set(R.FAIL, msg);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <param name="total"> 总记录数 </param>
        /// <returns></returns>
        public AjaxPage SetFail(string msg, object data, int total)
        {
            this.Set(R.FAIL, msg);
            return this.Set(data, total);
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
        /// <param name="total"> 总记录数 </param>
        /// <returns></returns>
        public static AjaxPage Ok(string msg, object data, int total)
        {
            return new AjaxPage().SetOk(msg, data, total);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <returns></returns>
        public static AjaxPage Fail(string msg)
        {
            return new AjaxPage().SetFail(msg);
        }

        /// <summary>
        /// 设置失败结果
        /// </summary>
        /// <param name="msg"> 返回消息 </param>
        /// <param name="data"> 数据对象 </param>
        /// <param name="total"> 总记录数 </param>
        /// <returns></returns>
        public static AjaxPage Fail(string msg, object data, int total)
        {
            return new AjaxPage().SetFail(msg, data, total);
        }

        /// <summary>
        /// 是否为成功结果
        /// </summary>
        /// <param name="ajaxPage"> ajax分页结果 </param>
        /// <returns></returns>
        public static bool IsSuccess(AjaxPage ajaxPage)
        {
            return ajaxPage != null && ajaxPage.IsSuccess();
        }

        /// <summary>
        /// 是否为错误结果
        /// </summary>
        /// <param name="ajaxPage"> ajax分页结果 </param>
        /// <returns></returns>
        public static bool IsError(AjaxPage ajaxPage)
        {
            return ajaxPage != null && ajaxPage.IsError();
        }
    }
}
