using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ZTool.Lang.Result;
using ZTool.Lang.Util;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// Http工具类
    /// </summary>
    public class HttpUtils
    {
        /// <summary>
        /// GET 请求
        /// </summary>
        public const string HTTP_METHOD_GET = "GET";

        /// <summary>
        /// POST 请求
        /// </summary>
        public const string HTTP_METHOD_POST = "POST";

        /// <summary>
        /// Http Get请求
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static R<string> GetString(string url, Encoding encoding)
        {
            return ExecuteString(url, HTTP_METHOD_GET, null, encoding);
        }

        /// <summary>
        /// Http Get请求
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="requestHandler"> 请求处理 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static R<string> GetString(string url, Action<HttpWebRequest> requestHandler, Encoding encoding)
        {
            return ExecuteString(url, HTTP_METHOD_GET, requestHandler, encoding);
        }

        /// <summary>
        /// Http Get请求
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="requestHandler"> 请求处理 </param>
        /// <param name="responseHandler"> 响应处理 </param>
        /// <returns></returns>
        public static R<int> Get(string url, Action<HttpWebRequest> requestHandler, Action<HttpWebResponse> responseHandler)
        {
            return Execute(url, HTTP_METHOD_GET, requestHandler, responseHandler);
        }

        /// <summary>
        /// Http Post请求
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="contentType"> 内容类型 </param>
        /// <param name="requestBody"> 请求主体 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static R<string> PostString(string url, string contentType, string requestBody, Encoding encoding)
        {
            return PostString(url, contentType, requestBody, null, encoding);
        }

        /// <summary>
        /// Http Post请求
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="contentType"> 内容类型 </param>
        /// <param name="requestBody"> 请求主体 </param>
        /// <param name="requestHandler"> 请求处理 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static R<string> PostString(string url, string contentType, string requestBody, Action<HttpWebRequest> requestHandler, Encoding encoding)
        {
            string responseContent = null;
            var retGet = ExecuteString(url, HTTP_METHOD_POST, request =>
            {
                request.ContentType = contentType;
                if (requestHandler != null)
                {
                    requestHandler(request);
                }
                using (var stream = request.GetRequestStream())
                {
                    IoUtils.WriteText(stream, requestBody, encoding);
                }
            }, encoding);
            if (!R.IsSuccess(retGet))
            {
                return R.Fail(retGet.Msg, responseContent);
            }
            return R.Ok(retGet.Msg, responseContent);
        }

        /// <summary>
        /// Http Post请求
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="requestHandler"> 请求处理 </param>
        /// <param name="responseHandler"> 响应处理 </param>
        /// <returns></returns>
        public static R<int> Post(string url, Action<HttpWebRequest> requestHandler, Action<HttpWebResponse> responseHandler)
        {
            return Execute(url, HTTP_METHOD_POST, requestHandler, responseHandler);
        }

        /// <summary>
        /// 执行 http 请求，返回字符串结果
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="method"> 请求方法 </param>
        /// <param name="requestHandler"> 请求处理 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static R<string> ExecuteString(string url, string method, Action<HttpWebRequest> requestHandler, Encoding encoding)
        {
            string responseContent = null;
            var retGet = Execute(url, method, requestHandler, response =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = response.GetResponseStream())
                    {
                        responseContent = IoUtils.ReadText(stream, encoding);
                    }
                }
            });
            if (!R.IsSuccess(retGet))
            {
                return R.Fail(retGet.Msg, responseContent);
            }
            return R.Ok(retGet.Msg, responseContent);
        }

        /// <summary>
        /// 执行 http 请求，返回数据流
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="method"> 请求方法 </param>
        /// <param name="requestHandler"> 请求处理 </param>
        /// <param name="inputStream"> 输入流 </param>
        /// <param name="outputStream"> 输出流 </param>
        /// <returns></returns>
        public static R<int> ExecuteStream(string url, string method, Action<HttpWebRequest> requestHandler, Stream inputStream, Stream outputStream)
        {
            return Execute(url, method, request =>
            {

                if (requestHandler != null)
                {
                    requestHandler(request);
                }
                // 输入流
                if (inputStream != null)
                {
                    using (var stream = request.GetRequestStream())
                    {
                        IoUtils.WriteStream(inputStream, stream);
                    }
                }
            }, response =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = response.GetResponseStream())
                    {
                        IoUtils.WriteStream(stream, outputStream);
                    }
                }
            });
        }

        /// <summary>
        /// 执行 http 请求
        /// </summary>
        /// <param name="url"> 请求URL </param>
        /// <param name="method"> 请求方法 </param>
        /// <param name="requestHandler"> 请求处理 </param>
        /// <param name="responseHandler"> 响应处理 </param>
        /// <returns></returns>
        public static R<int> Execute(string url, string method, Action<HttpWebRequest> requestHandler, Action<HttpWebResponse> responseHandler)
        {
            HttpWebRequest request = null;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = method;
                request.ServicePoint.Expect100Continue = false;
                request.KeepAlive = false;
                if (requestHandler != null)
                {
                    requestHandler(request);
                }
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (responseHandler != null)
                    {
                        responseHandler(response);
                    }
                    return R.Ok(response.StatusDescription, (int)response.StatusCode);
                }
            }
            catch (Exception e)
            {
                return R.Fail(e.Message, -1);
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
            }
        }
    }
}
