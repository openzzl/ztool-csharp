using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Design.Singleton
{
    /// <summary>
    /// 懒汉模式单例
    /// </summary>
    public class LazySingleton<T> : ISingleton<T>
    {
        /// <summary>
        /// 同步锁访问对象
        /// </summary>
        private object syncObj;

        /// <summary>
        /// 实例对象
        /// </summary>
        private T instance;

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public T GetInstance()
        {
            return this.instance;
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="func">  实例提供者 </param>
        /// <returns></returns>
        public T GetInstance(Func<T> func)
        {
            if (this.instance == null)
            {
                lock (this.syncObj)
                {
                    // 双检锁优化，减少锁的开销
                    if (this.instance == null)
                    {
                        this.instance = func != null ? func() : default(T);
                    }
                }
            }
            return this.instance;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="syncObj"> 同步锁对象 </param>
        public LazySingleton(object syncObj)
        {
            this.syncObj = syncObj != null ? syncObj : this;
        }
    }
}
