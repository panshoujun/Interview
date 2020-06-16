using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 时间拓展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="millisecond">是否毫秒级,true毫秒级(默认值)</param>
        /// <returns></returns>
        public static long ToTimestamp(this DateTime dt, bool millisecond = true)
        {
            /*
             * ticks的单位是100纳秒,1 Tick=100纳秒,所以需要除以10000000(秒),10000(毫秒)
             *  s(秒),ms(毫秒),μs(微秒),ns(纳秒),1s=1000ms,1 ms=1000μs,1μs=1000ns
             */
            int divisor = millisecond ? 10000 : 10000000;
            long dt_ticks = dt.ToUniversalTime().Ticks;
            return (dt_ticks - Const.TiksUtc1970) / divisor;
        }

        /// <summary>
        /// 时间戳转换成时间,返回NULL则说明转换失败(如时间戳无效)
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <param name="millisecond">是否毫秒级,true毫秒级(默认值)</param>
        /// <param name="localTime">是否输出本地时间,true本地时间(默认值)</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this long timestamp, bool millisecond = true, bool localTime = true)
        {
            try
            {
                int ms = millisecond ? 10000 : 10000000;
                var dt = new DateTime(Const.TiksUtc1970 + timestamp * ms, DateTimeKind.Utc);
                if (localTime)
                    dt.ToLocalTime();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 时间戳转换成时间
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <param name="millisecond">是否毫秒级,true毫秒级(默认值)</param>
        /// <param name="localTime">是否输出本地时间,true本地时间(默认值)</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string timestamp, bool millisecond = true, bool localTime = true)
        {
            if (long.TryParse(timestamp, out long ts))
            {
                return ts.ToDateTime(millisecond, localTime);
            }
            return null;
        }
    }

    /// <summary>
    /// 常量定义
    /// </summary>
    public class Const
    {
        /// <summary>
        /// 日期时间格式化
        /// </summary>
        public const string DateTimeFormatString = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 日期时间格式化
        /// </summary>
        public const string DateHmFormatString = "yyyy-MM-dd HH:mm";

        /// <summary>
        /// 日期格式化
        /// </summary>
        public const string DateFormatString = "yyyy-MM-dd";

        /// <summary>
        /// utc 1601-1-1 到 utc 1970-1-1 的 Ticks
        /// </summary>
        public const long TiksUtc1970 = 621355968000000000;
    }


    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtension2
    {
        /// <summary>
        /// 时间戳转成时间类型
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTime(this string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 时间类型转成long
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeInt(this DateTime time)
        {
            long intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (long)(time - startTime).TotalSeconds;
            return intResult;
        }
    }
}
