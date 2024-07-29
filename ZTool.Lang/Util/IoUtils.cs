using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// IO工具类
    /// </summary>
    public class IoUtils
    {
        /// <summary>
        /// 默认字符编码
        /// </summary>
        public static Encoding DEFAULT_ENCODING =  Encoding.UTF8;

        /// <summary>
        /// 默认缓冲区大小4K
        /// </summary>
        public static int DEFAULT_BUFFER_SIZE = 1024 * 4;

        /// <summary>
        /// 创建内存流
        /// </summary>
        /// <returns></returns>
        public static MemoryStream CreateMemoryStream()
        {
            return new MemoryStream();
        }

        /// <summary>
        /// 创建文件流
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <param name="fileMode"> 文件打开模式 </param>
        /// <param name="fileAccess"> 文件访问方式 </param>
        /// <returns></returns>
        public static FileStream CreateFileStream(string path, FileMode fileMode, FileAccess fileAccess)
        {
            return new FileStream(path, fileMode, fileAccess, FileShare.ReadWrite);
        }

        /// <summary>
        /// 读取数据流为字节数组
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <returns></returns>
        public static byte[] ReadBytes(Stream srcStream)
        {
            return ReadBytes(srcStream, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 读取数据流为字节数组
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="bufferSize"> 数据缓冲区大小 </param>
        /// <returns></returns>
        public static byte[] ReadBytes(Stream srcStream, int bufferSize)
        {
            if (srcStream is MemoryStream)
            {
                return ((MemoryStream)srcStream).ToArray();
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    WriteStream(srcStream, ms, bufferSize > 0 ? bufferSize : DEFAULT_BUFFER_SIZE);
                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// 读取数据流为文本
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <returns></returns>
        public static string ReadText(Stream srcStream)
        {
            return ReadText(srcStream, DEFAULT_ENCODING, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 读取数据流为文本
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string ReadText(Stream srcStream, Encoding encoding)
        {
            return ReadText(srcStream, encoding, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 读取数据流为文本
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <param name="bufferSize"> 数据缓冲区大小 </param>
        /// <returns></returns>
        public static string ReadText(Stream srcStream, Encoding encoding, int bufferSize)
        {
            byte[] bytes = ReadBytes(srcStream, bufferSize);
            return (encoding ?? DEFAULT_ENCODING).GetString(bytes);
        }

        /// <summary>
        /// 读取数据流为多行文本
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <returns></returns>
        public static List<string> ReadLines(Stream srcStream)
        {
            return ReadLines(srcStream, DEFAULT_ENCODING, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 读取数据流为多行文本
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static List<string> ReadLines(Stream srcStream, Encoding encoding)
        {
            return ReadLines(srcStream, encoding, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 读取数据流为多行文本
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <param name="bufferSize"> 数据缓冲区大小 </param>
        /// <returns></returns>
        public static List<string> ReadLines(Stream srcStream, Encoding encoding, int bufferSize)
        {
            using (var reader = new StreamReader(srcStream, encoding ?? DEFAULT_ENCODING, true, bufferSize))
            {
                var lines = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                return lines;
            }
        }

        /// <summary>
        /// 将输入流写入到数据流
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="distStream"> 目标数据流 </param>
        public static void WriteStream(Stream srcStream, Stream distStream)
        {
            WriteStream(srcStream, distStream, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 将输入流写入到数据流
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="bufferSize"> 数据缓冲区 </param>
        public static void WriteStream(Stream srcStream, Stream distStream, int bufferSize)
        {
            // bufferSize
            if (bufferSize <= 0)
            {
                bufferSize = DEFAULT_BUFFER_SIZE;
            }
#if NET35
            byte[] array = new byte[bufferSize];
            int count;
            while ((count = srcStream.Read(array, 0, array.Length)) != 0)
            {
                distStream.Write(array, 0, count);
            }
#else
            srcStream.CopyTo(distStream, bufferSize);
#endif
        }

        /// <summary>
        /// 将字节数组写入到数据流
        /// </summary>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="bytes"> 字节数组 </param>
        public static void WriteBytes(Stream distStream, byte[] bytes)
        {
            distStream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 将文本写入到数据流
        /// </summary>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="text"> 文本 </param>
        public static void WriteText(Stream distStream, string text)
        {
            WriteText(distStream, text, DEFAULT_ENCODING, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 将文本写入到数据流
        /// </summary>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="text"> 文本 </param>
        /// <param name="encoding"> 字符编码 </param>
        public static void WriteText(Stream distStream, string text, Encoding encoding)
        {
            WriteText(distStream, text, encoding, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 将文本写入到数据流
        /// </summary>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="text"> 文本 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <param name="bufferSize"> 数据缓冲区 </param>
        public static void WriteText(Stream distStream, string text, Encoding encoding, int bufferSize)
        {
            using (var writer = new StreamWriter(distStream, encoding, bufferSize))
            {
                writer.Write(text);
            }
        }

        /// <summary>
        /// 将多行文本写入到数据流
        /// </summary>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="lines"> 多行文本 </param>
        public static void WriteLines(Stream distStream, List<string> lines)
        {
            WriteLines(distStream, lines, DEFAULT_ENCODING, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 将多行文本写入到数据流
        /// </summary>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="lines"> 多行文本 </param>
        /// <param name="encoding"> 字符编码 </param>
        public static void WriteLines(Stream distStream, List<string> lines, Encoding encoding)
        {
            WriteLines(distStream, lines, encoding, DEFAULT_BUFFER_SIZE);
        }

        /// <summary>
        /// 将多行文本写入到数据流
        /// </summary>
        /// <param name="distStream"> 目标数据流 </param>
        /// <param name="lines"> 多行文本 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <param name="bufferSize"> 数据缓冲区 </param>
        public static void WriteLines(Stream distStream, List<string> lines, Encoding encoding, int bufferSize)
        {
            using (var writer = new StreamWriter(distStream, encoding, bufferSize))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Gzip 压缩
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="distStream"> 目标数据流 </param>
        public static void CompressGzip(Stream srcStream, Stream distStream)
        {
            using (var gzipStream = new GZipStream(distStream, CompressionMode.Compress))
            {
                WriteStream(srcStream, gzipStream);
            }
        }

        /// <summary>
        /// Gzip 解压
        /// </summary>
        /// <param name="srcStream"> 源数据流 </param>
        /// <param name="distStream"> 目标数据流 </param>
        public static void DecompressGzip(Stream srcStream, Stream distStream)
        {
            using (var gzipStream = new GZipStream(srcStream, CompressionMode.Decompress))
            {
                WriteStream(gzipStream, distStream);
            }
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        /// <param name="disposable"> 可释放对象 </param>
        public static void Dispose(IDisposable disposable)
        {
            if (disposable == null)
            {
                return;
            }
            disposable.Dispose();
        }
    }
}
