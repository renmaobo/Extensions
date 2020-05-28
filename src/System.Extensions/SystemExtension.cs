using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Extensions
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class SystemExtension
    {
        /// <summary>
        /// 转化为MD5值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMD5String(this string value)
        {
            return null;
        }

        /// <summary>
        /// 转化为字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string value, Encoding encoding)
        {
            return encoding.GetBytes(value);
        }

        /// <summary>
        /// 转化为utf-8格式的字节数组
        /// </summary>
        /// <param name="value">待转化字符串</param>
        /// <returns></returns>
        public static byte[] ToUTF8(this string value)
        {
            return value.ToBytes(Encoding.UTF8);
        }
    }
}
