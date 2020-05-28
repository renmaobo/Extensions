using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Net
{
    /// <summary>
    /// web客户端扩展
    /// </summary>
    public static class WebClientExtension
    {
        /// <summary>
        /// http get请求
        /// </summary>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="url"></param>
        /// <param name="headerSetting"></param>
        /// <param name="queryStringSetting"></param>
        /// <returns></returns>
        public static Tout HttpGet<Tout>(this string url, Action<WebHeaderCollection> headerSetting = null, Action<NameValueCollection> queryStringSetting = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headerSetting != null)
                {
                    headerSetting(client.Headers);
                }
                else
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                }

                if (queryStringSetting != null)
                    queryStringSetting(client.QueryString);

                byte[] bytes = client.DownloadData(url);
#if DEBUG
                string jsonString = Encoding.UTF8.GetString(bytes);

                return JsonConvert.DeserializeObject<Tout>(jsonString);
#endif
#if !DEBUG
                return JsonConvert.DeserializeObject<Tout>( Encoding.UTF8.GetString(bytes));
#endif
            }
        }

        /// <summary>
        /// http post请求
        /// </summary>
        /// <typeparam name="Tinput"></typeparam>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="url"></param>
        /// <param name="input"></param>
        /// <param name="headerSetting"></param>
        /// <param name="queryStringSetting"></param>
        /// <returns></returns>
        public static Tout HttpPost<Tinput, Tout>(this string url, Tinput input, Action<WebHeaderCollection> headerSetting = null, Action<NameValueCollection> queryStringSetting = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headerSetting != null)
                {
                    headerSetting(client.Headers);
                }
                else
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                }

                if (queryStringSetting != null)
                    queryStringSetting(client.QueryString);

                string inputValue = string.Empty;
                if (input != null)
                {
                    inputValue = JsonConvert.SerializeObject(input);
                }

                byte[] bytes = client.UploadData(url, Encoding.UTF8.GetBytes(inputValue));
#if DEBUG
                string jsonString = Encoding.UTF8.GetString(bytes);

                return JsonConvert.DeserializeObject<Tout>(jsonString);
#endif
#if !DEBUG
                return JsonConvert.DeserializeObject<Tout>( Encoding.UTF8.GetString(bytes));
#endif
            }
        }

        /// <summary>
        /// http post请求
        /// </summary>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="url"></param>
        /// <param name="headerSetting"></param>
        /// <param name="queryStringSetting"></param>
        /// <returns></returns>
        public static Tout HttpPost<Tout>(this string url, Action<WebHeaderCollection> headerSetting = null, Action<NameValueCollection> queryStringSetting = null)
        {
            return url.HttpPost<object, Tout>(url, headerSetting, queryStringSetting);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="filePath">文件地址</param>
        /// <param name="headerSetting"></param>
        /// <param name="queryStringSetting"></param>
        /// <returns></returns>
        public static Tout UploadFile<Tout>(this string url, string filePath, Action<WebHeaderCollection> headerSetting = null, Action<NameValueCollection> queryStringSetting = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headerSetting != null)
                    headerSetting(client.Headers);

                if (queryStringSetting != null)
                    queryStringSetting(client.QueryString);

                byte[] bytes = client.UploadFile(url, filePath);
#if DEBUG
                string jsonString = Encoding.UTF8.GetString(bytes);

                return JsonConvert.DeserializeObject<Tout>(jsonString);
#endif
#if !DEBUG
                return JsonConvert.DeserializeObject<Tout>( Encoding.UTF8.GetString(bytes));
#endif
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="headerSetting"></param>
        /// <param name="queryStringSetting"></param>
        public static void DownloadFile(this string url, string fileName, Action<WebHeaderCollection> headerSetting = null, Action<NameValueCollection> queryStringSetting = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headerSetting != null)
                    headerSetting(client.Headers);

                if (queryStringSetting != null)
                    queryStringSetting(client.QueryString);

                client.DownloadFile(url, fileName);
            }
        }

        /// <summary>
        /// 下载数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headerSetting"></param>
        /// <param name="queryStringSetting"></param>
        /// <returns></returns>
        public static DownloadResultBody DownloadData(this string url, Action<WebHeaderCollection> headerSetting = null, Action<NameValueCollection> queryStringSetting = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headerSetting != null)
                    headerSetting(client.Headers);

                if (queryStringSetting != null)
                    queryStringSetting(client.QueryString);

                byte[] bytes = client.DownloadData(url);

                HttpHeader header = client.ResponseHeaders.GetHttpHeader();

                return new DownloadResultBody(header, bytes);
            }
        }

        /// <summary>
        /// 获取Http响应头
        /// </summary>
        /// <param name="webHeaderCollection"></param>
        /// <returns></returns>
        public static HttpHeader GetHttpHeader(this WebHeaderCollection webHeaderCollection)
        {
            HttpHeader httpHeader = new HttpHeader();
            PropertyInfo[] propertyInfos = httpHeader.GetType().GetProperties().GetPropertyInfos<HttpHeadFieldAttribute>().ToArray();
            foreach (string key in webHeaderCollection.AllKeys)// 对HttpHeader实体赋值
            {
#if NET40
                PropertyInfo field = propertyInfos.FirstOrDefault(e =>
                {
                    var attributes = e.GetCustomAttributes(typeof(HttpHeadFieldAttribute), false);
                    if (attributes != null && attributes.Length > 0)
                    {
                        return attributes.Select(v => v as HttpHeadFieldAttribute).FirstOrDefault().Name.Equals(key);
                    }
                    return false;
                });
                field.SetValue(httpHeader, webHeaderCollection[key], BindingFlags.Public, null, null, null);
#endif
#if NET45
                PropertyInfo field = propertyInfos.FirstOrDefault(e => e.GetCustomAttribute<HttpHeadFieldAttribute>().Name.Equals(key));
                if (null != field)
                {
                    field.SetValue(httpHeader, webHeaderCollection[key]);
                }
#endif
            }

            httpHeader.DisposeFileName();
            return httpHeader;
        }

        /// <summary>
        /// 获取指定特性的属性
        /// </summary>
        /// <typeparam name="T">要获取的特性</typeparam>
        /// <param name="source">属性数据集</param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertyInfos<T>(this IEnumerable<PropertyInfo> source) where T : Attribute
        {
            foreach (PropertyInfo item in source)
            {
#if NET45
                if (null != item.GetCustomAttribute<T>())
#endif
#if NET40
                var attributes = item.GetCustomAttributes(typeof(T), false);
                if (null != attributes && attributes.Length > 0)
#endif
                    yield return item;
            }
        }
    }
}
