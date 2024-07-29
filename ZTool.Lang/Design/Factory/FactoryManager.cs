using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Design.Factory
{
    /// <summary>
    /// 工厂管理器抽象类
    /// </summary>
    public abstract class FactoryManager<K, V> where V : IFactory<K>
    {
        /// <summary>
        /// 默认Key
        /// </summary>
        public static readonly string DEFAULT_STRING__KEY = "";

        /// <summary>
        /// 工厂实例字典
        /// </summary>
        private readonly IDictionary<K, V> factoryDict;

        /// <summary>
        /// 初始化
        /// </summary>
        public FactoryManager()
        {
#if NET35
            this.factoryDict = new Dictionary<K, V>();
#else
            this.factoryDict = new System.Collections.Concurrent.ConcurrentDictionary<K, V>();
#endif

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public FactoryManager(IDictionary<K, V> factoryDict)
        {
            this.factoryDict = factoryDict;
        }

        /// <summary>
        /// 获取默认工厂实例
        /// </summary>
        /// <returns></returns>
        public abstract V GetDefaultFactory();
    }
}
