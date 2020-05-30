using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 获取当前时间戳(seconds)
        /// </summary>
        /// <param name="currentDateTime">当前时间</param>
        /// <returns></returns>
        public static long GetCurrentTimestamp(this DateTime currentDateTime)
        {
            TimeSpan timeSpan = (currentDateTime - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime());
            return (long)timeSpan.TotalSeconds;
        }
    }
}
