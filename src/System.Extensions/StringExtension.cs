using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.Extensions
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtension
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
        public static byte[] ToUtf8Bytes(this string value)
        {
            return value.ToBytes(Encoding.UTF8);
        }

        /// <summary>
        /// 空类型或空值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 空值或空白
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 转化为bool值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this string value)
        {
            if (Regex.IsMatch(value, "(true)|1", RegexOptions.IgnoreCase))
                return true;
            if (Regex.IsMatch(value, "(false)|0", RegexOptions.IgnoreCase))
                return false;
            throw new FormatException($"value because format error. value:{value}");
        }
    }
}
