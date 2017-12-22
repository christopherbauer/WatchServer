using System;

namespace WatchServer.Core.Services
{
    public interface IDateTimeService
    {
        DateTime GetCurrentUTCDate();
    }
}