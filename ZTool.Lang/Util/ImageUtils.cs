using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 图像工具类
    /// </summary>
    public class ImageUtils
    {
        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="filename"> 图片文件 </param>
        /// <returns></returns>
        public static System.Drawing.Image LoadImage(string filename)
        {
            return System.Drawing.Image.FromFile(filename);
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="bytes"> 字节数组 </param>
        /// <returns></returns>
        public static System.Drawing.Image LoadImage(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                return LoadImage(stream);
            }
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="stream"> 图片输入流 </param>
        /// <returns></returns>
        public static System.Drawing.Image LoadImage(Stream stream)
        {
            return System.Drawing.Image.FromStream(stream);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image"> 图片对象 </param>
        /// <param name="filename"> 图片文件 </param>
        public static void SaveImage(System.Drawing.Image image, string filename)
        {
            image.Save(filename);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image"> 图片对象 </param>
        /// <param name="filename"> 图片文件 </param>
        /// <param name="format"> 图片格式 </param>
        public static void SaveImage(System.Drawing.Image image, string filename, System.Drawing.Imaging.ImageFormat format)
        {
            image.Save(filename, format);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image"> 图片对象 </param>
        /// <param name="format"> 图片格式 </param>
        public static byte[] SaveImage(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                SaveImage(image, ms, format);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image"> 图片对象 </param>
        /// <param name="stream"> 图片输出流 </param>
        /// <param name="format"> 图片格式 </param>
        public static void SaveImage(System.Drawing.Image image, System.IO.Stream stream, System.Drawing.Imaging.ImageFormat format)
        {
            image.Save(stream, format);
        }

        /// <summary>
        /// 判断图片位置是否透明色
        /// </summary>
        /// <param name="bitmap"> 图片 </param>
        /// <param name="x"> x坐标 </param>
        /// <param name="y"> y坐标 </param>
        /// <returns></returns>
        public static bool IsTransparent(Bitmap bitmap, int x, int y)
        {
            Color pixelColor = bitmap.GetPixel(x, y);
            return pixelColor.A == 0; // 完全透明
        }

        /// <summary>
        /// 获取图片透明区域
        /// </summary>
        /// <param name="bitmap"> 图片 </param>
        /// <returns></returns>
        public static List<Rectangle> GetTransparentRectangles(Bitmap bitmap)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            bool[,] visited = new bool[bitmap.Width, bitmap.Height];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (!visited[x, y] && IsTransparent(bitmap, x, y))
                    {
                        Rectangle rect = GetTransparentRectangle(bitmap, x, y, visited);
                        rectangles.Add(rect);
                    }
                }
            }
            return rectangles;
        }

        /// <summary>
        /// 获取图片透明区域
        /// </summary>
        /// <param name="bitmap"> 图片 </param>
        /// <param name="startX"> x </param>
        /// <param name="startY"> y </param>
        /// <param name="visited"> </param>
        /// <returns></returns>
        private static Rectangle GetTransparentRectangle(Bitmap bitmap, int startX, int startY, bool[,] visited)
        {
            int minX = startX;
            int maxX = startX;
            int minY = startY;
            int maxY = startY;

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(startX, startY));
            visited[startX, startY] = true;

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();
                int currentX = current.X;
                int currentY = current.Y;

                // Expand the rectangle
                if (currentX < minX) minX = currentX;
                if (currentX > maxX) maxX = currentX;
                if (currentY < minY) minY = currentY;
                if (currentY > maxY) maxY = currentY;

                // Check the neighboring pixels
                for (int y = currentY - 1; y <= currentY + 1; y++)
                {
                    for (int x = currentX - 1; x <= currentX + 1; x++)
                    {
                        if (x >= 0 && x < bitmap.Width && y >= 0 && y < bitmap.Height && !visited[x, y] && IsTransparent(bitmap, x, y))
                        {
                            queue.Enqueue(new Point(x, y));
                            visited[x, y] = true;
                        }
                    }
                }
            }

            return new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
        }
    }
}
