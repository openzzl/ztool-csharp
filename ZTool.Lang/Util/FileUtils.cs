using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 文件工具类
    /// </summary>
    public class FileUtils
    {
        #region 文件
        
        /// <summary>
        /// 获取文件名称
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <returns></returns>
        public static string GetFileExtension(string path)
        {
            return Path.GetExtension(path);
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <returns></returns>
        public static long GetFileLength(string path)
        {
            if (!ExistsFile(path))
            {
                return -1;
            }
            return new FileInfo(path).Length;
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <returns></returns>
        public static bool ExistsFile(string path)
        {
            return !string.IsNullOrEmpty(path) && File.Exists(path);
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourceFileName"> 源文件 </param>
        /// <param name="destFileName"> 目标文件 </param>
        public static void CopyFile(string sourceFileName, string destFileName)
        {
            File.Copy(sourceFileName, destFileName);
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="sourceFileName"> 源文件 </param>
        /// <param name="destFileName"> 目标文件 </param>
        public static void MoveFile(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        public static void DeleteFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }
            File.Delete(path);
        }

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <returns></returns>
        public static FileInfo GetFileInfo(string path)
        {
            return string.IsNullOrEmpty(path) ? null : new FileInfo(path);
        }

        /// <summary>
        /// 获取目录文件
        /// </summary>
        /// <param name="path"> 路径 </param>
        /// <param name="searchPattern"> 搜索表达式 </param>
        /// <returns></returns>
        public static string[] GetFiles(string path, string searchPattern = null)
        {
            if (!Directory.Exists(path))
            {
                return new string[] { };
            }
            if (string.IsNullOrEmpty(searchPattern))
            {
                return Directory.GetFiles(path);
            }
            else
            {
                return Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
            }
        }

        #endregion

        #region Directory

        /// <summary>
        /// 获取目录名称
        /// </summary>
        /// <param name="path"> 目录路径 </param>
        /// <returns></returns>
        public static string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        /// <summary>
        /// 获取当前工作目录
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            return Environment.CurrentDirectory;
        }

        /// <summary>
        /// 获取系统目录
        /// </summary>
        /// <returns></returns>
        public static string GetSystemDirectory()
        {
            return Environment.SystemDirectory;
        }

        /// <summary>
        /// 获取桌面目录
        /// </summary>
        /// <returns></returns>
        public static string GetDesktopDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

#if !NET35

        /// <summary>
        /// 获取用户目录
        /// </summary>
        /// <returns></returns>
        public static string GetUserProfileDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
#endif

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"> 目录 </param>
        public static void CreateDirectory(string path)
        {
            if(Directory.Exists(path))
            {
                return;
            }
            Directory.CreateDirectory(path);
        }

        #endregion

        #region 读/写

        /// <summary>
        /// 读取整个文件所有数据
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <returns></returns>

        public static byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// 读取整个文件所有文本
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string ReadAllText(string path, Encoding encoding = null)
        {
            return File.ReadAllText(path, encoding ?? IoUtils.DEFAULT_ENCODING);
        }

        /// <summary>
        /// 读取整个文件所有行
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string[] ReadAllLines(string path, Encoding encoding = null)
        {
            return File.ReadAllLines(path, encoding ?? IoUtils.DEFAULT_ENCODING);
        }

        /// <summary>
        /// 将字节数组写入到整个文件
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <param name="bytes"> 字节数组 </param>
        public static void WriteAllBytes(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// 将文本写入到整个文件
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <param name="text"> 文本 </param>
        /// <param name="encoding"> 字符编码</param>
        public static void WriteAllText(string path, string text, Encoding encoding = null)
        {
            File.WriteAllText(path, text, encoding ?? IoUtils.DEFAULT_ENCODING);
        }

        /// <summary>
        /// 将文本行写入到整个文件
        /// </summary>
        /// <param name="path"> 文件路径 </param>
        /// <param name="lines"> 文本行 </param>
        /// <param name="encoding"> 字符编码 </param>
        public static void WriteAllLines(string path, string[] lines, Encoding encoding = null)
        {
            File.WriteAllLines(path, lines, encoding ?? IoUtils.DEFAULT_ENCODING);
        }

        #endregion
    }
}
