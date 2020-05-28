using System;
namespace System.Extensions
{
    /// <summary>
    /// 整型扩展
    /// </summary>
    public static class IntExtension
    {
        /// <summary>
        /// 转化为布尔值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this int value)
        {
            if (value == 0)
                return false;
            return true;
        }
    }
}