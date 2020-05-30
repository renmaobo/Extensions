using System;
namespace System
{
    public static class LongExtension
    {
        /// <summary>
        /// 转化为日期时间
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timestamp)
        {
            DateTime startDateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
            TimeSpan nowTimeSpan = new TimeSpan(timestamp);
            return startDateTime.Add(nowTimeSpan);
        }
    }
}
