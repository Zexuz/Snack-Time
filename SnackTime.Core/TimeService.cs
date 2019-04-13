using System;
using System.Globalization;

namespace SnackTime.Core
{
    public class TimeService
    {
        public static DateTimeOffset Parse(string timeString)
        {
            return DateTimeOffset.Parse(timeString, CultureInfo.InvariantCulture);
        }

        public DateTimeOffset GetCurrentTime()
        {
            return DateTimeOffset.UtcNow;
        }

        public string GetCurrentTimeAsString()
        {
            return GetCurrentTime().ToString(CultureInfo.InvariantCulture);
        }
    }
}