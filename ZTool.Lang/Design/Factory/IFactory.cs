using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Design.Factory
{
    /// <summary>
    /// 工厂实例接口
    /// </summary>
    /// <typeparam name="K">实例类型</typeparam>
    public interface IFactory<K>
    {
        /// <summary>
        /// 获取工厂实例key
        /// </summary>
        /// <returns></returns>
        K GetKey();
    }
}
