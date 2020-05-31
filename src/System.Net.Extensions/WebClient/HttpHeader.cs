using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.Net
{
    /// <summary>
    /// Http消息头
    /// </summary>
    public class HttpHeader
    {
        /// <summary>
        /// 链接
        /// </summary>
        [HttpHeadField(Name = "Connection")]
        public string Connection { get; protected set; }

        /// <summary>
        /// 内容类型
        /// </summary>
        [HttpHeadField(Name = "Content-Type")]
        public string ContentType { get; protected set; }

        /// <summary>
        /// 内容信息
        /// </summary>
        [HttpHeadField(Name = "Content-disposition")]
        public string ContentDisposition { get; protected set; }

        /// <summary>
        /// 消息响应日期
        /// </summary>
        [HttpHeadField(Name = "Date")]
        public string Date { get; protected set; }

        /// <summary>
        /// 请求/响应指定
        /// </summary>
        [HttpHeadField(Name = "Cache-Control")]
        public string CacheControl { get; protected set; }

        /// <summary>
        /// body长度,单位是字节长度(byte)
        /// </summary>
        [HttpHeadField(Name = "Content-Length")]
        public string ContentLength { get; protected set; }

        public string FileName { get; set; }

        /// <summary>
        /// 处理文件名称
        /// </summary>
        internal void DisposeFileName()
        {
            string[] array = this.ContentDisposition.Split(';');

            string fileName = array.FirstOrDefault(e => Regex.IsMatch(e, "filename=", RegexOptions.IgnoreCase));
            if (!string.IsNullOrEmpty(fileName))
            {
                this.FileName = fileName.Replace("\"", "").Split('=')[1];
            }
        }
    }
}
