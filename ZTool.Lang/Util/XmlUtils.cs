using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// XML工具类
    /// </summary>
    public class XmlUtils
    {
        /// <summary>
        /// 将对象序列化为XML
        /// </summary>
        /// <param name="obj"> 对象 </param>
        public static byte[] Serialize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                Serialize(obj, ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 将对象序列化为XML
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"> 输出流 </param>
        public static void Serialize(object obj, Stream stream)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            xmlSerializer.Serialize(stream, obj);
        }

        /// <summary>
        /// 将XML反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"> 字节数组 </param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes) where T : class
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Deserialize<T>(ms);
            }
        }

        /// <summary>
        /// 将XML反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"> 输入流 </param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream) where T : class
        {
            return new XmlSerializer(typeof(T)).Deserialize(stream) as T;
        }

        /// <summary>
        /// 创建XML文档对象
        /// </summary>
        /// <returns></returns>
        public static XmlDocument CreateXmlDocument()
        {
            return new XmlDocument();
        }

        /// <summary>
        /// 从文件加载XML文档对象
        /// </summary>
        /// <param name="fileName"> 文件名 </param>
        /// <returns></returns>
        public static XmlDocument LoadXmlDocument(string fileName)
        {
            var doc = CreateXmlDocument();
            doc.Load(fileName);
            return doc;
        }

        /// <summary>
        /// 从字节数组加载XML文档对象
        /// </summary>
        /// <param name="bytes"> 字节数组 </param>
        /// <returns></returns>
        public static XmlDocument LoadXmlDocument(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return LoadXmlDocument(ms);
            }
        }

        /// <summary>
        /// 从数据流加载XML文档对象
        /// </summary>
        /// <param name="stream"> 数据流 </param>
        /// <returns></returns>
        public static XmlDocument LoadXmlDocument(Stream stream)
        {
            var doc = CreateXmlDocument();
            doc.Load(stream);
            return doc;
        }

        /// <summary>
        /// 保存XML文档到文件
        /// </summary>
        /// <param name="document"> xml文档 </param>
        /// <param name="fileName"> 文件名 </param>
        public static void SaveXmlDocument(XmlDocument document, string fileName)
        {
            document.Save(fileName);
        }

        /// <summary>
        /// 保存XML文档到数据流
        /// </summary>
        /// <param name="document"> xml文档 </param>
        /// <param name="stream"> 数据流 </param>
        public static void SaveXmlDocument(XmlDocument document, Stream stream)
        {
            document.Save(stream);
        }

        /// <summary>
        /// 保存XML文档为字节数组
        /// </summary>
        /// <param name="document"> xml文档 </param>
        public static byte[] SaveXmlDocument(XmlDocument document)
        {
            using (var ms = new MemoryStream())
            {
                document.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
