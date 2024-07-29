using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Design.Singleton
{
    /// <summary>
    /// 单例接口
    /// </summary>
    public interface ISingleton<T>
    {
        /// <summary>
        /// 获取单例实例。
        /// </summary>
        /// <returns> 单例实例 </returns>
        T GetInstance();
    }
}
