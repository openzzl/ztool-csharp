using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Design.Singleton
{
    /// <summary>
    /// 饿汉模式单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EagerSingleton<T> : ISingleton<T>
    {
        /// <summary>
        /// 实例对象
        /// </summary>
        private readonly T instance;

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public T GetInstance()
        {
            return this.instance;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="instance"></param>
        public EagerSingleton(T instance)
        {
            this.instance = instance;
        }
    }
}
