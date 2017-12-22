using System;

namespace WatchServer.Core.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentUTCDate()
        {
            System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
            return DateTime.UtcNow;
        }
    }
}