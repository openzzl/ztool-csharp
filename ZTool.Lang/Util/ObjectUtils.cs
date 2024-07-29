using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 对象工具类
    /// </summary>
    public class ObjectUtils
    {
        /// <summary>
        /// 获取对象的值
        /// </summary>
        /// <typeparam name="T"> 对象类型 </typeparam>
        /// <typeparam name="R"> 返回类型 </typeparam>
        /// <param name="obj"> 对象 </param>
        /// <param name="func"> 提供者 </param>
        /// <returns></returns>
        public static R GetValue<T, R>(T obj, Func<T, R> func)
        {
            if(obj == null)
            {
                return default(R);
            }
            return func(obj);
        }
    }
}
