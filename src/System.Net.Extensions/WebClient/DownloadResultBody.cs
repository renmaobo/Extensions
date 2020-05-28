using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net
{
    /// <summary>
    /// 下载结果体
    /// </summary>
    public class DownloadResultBody
    {
        /// <summary>
        /// 下载结果体
        /// </summary>
        /// <param name="header">响应头</param>
        /// <param name="body">响应内容</param>
        public DownloadResultBody(HttpHeader header, byte[] body)
        {
            this.Header = header;
            this.Body = body;
        }

        /// <summary>
        /// 消息头
        /// </summary>
        [JsonProperty("header")]
        public HttpHeader Header { get; set; }

        /// <summary>
        /// 数据体
        /// </summary>
        [JsonProperty("body")]
        public byte[] Body { get; set; }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="saveDirectory">保存路径</param>
        /// <param name="fileName">文件名称</param>
        public virtual void SaveFile(string saveDirectory, string fileName = "")
        {
            if (!Directory.Exists(saveDirectory)) Directory.CreateDirectory(saveDirectory);

            string savePath = string.Empty;
            if (string.IsNullOrEmpty(fileName))
            {
                savePath = Path.Combine(saveDirectory, this.Header.FileName);
            }
            else
            {
                savePath = Path.Combine(saveDirectory, fileName);
            }
            File.WriteAllBytes(savePath, this.Body);
        }
    }
}
