using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Result
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// 是否为成功结果
        /// </summary>
        /// <returns></returns>
        bool IsSuccess();

        /// <summary>
        /// 是否为错误结果
        /// </summary>
        /// <returns></returns>
        bool IsError();
    }
}
