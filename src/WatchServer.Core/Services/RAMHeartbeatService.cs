using System;
using System.Diagnostics;
using System.Management;
using System.Threading;
using WatchServer.Core.Services.Reporting;

namespace WatchServer.Core.Services
{
    public class RAMHeartbeatService : IHeartbeatService
    {
        private readonly IReportingService _reportingService;
        readonly PerformanceCounter _ramCounter = new PerformanceCounter();

        private Timer timer;
        private uint _totalRam;

        public RAMHeartbeatService(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        public void WriteMetric()
        {
            _reportingService.WriteMetric(MetricCode.PercentRAM, ((int)_ramCounter.NextValue()) / _totalRam);
        }

        public void StartCollecting()
        {
            _ramCounter.CategoryName = "Memory";
            _ramCounter.CounterName = "Available Bytes";
            _ramCounter.ReadOnly = true;

            var Query = "SELECT MaxCapacity FROM Win32_PhysicalMemoryArray";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            foreach (ManagementObject WniPART in searcher.Get())
            {
                _totalRam = Convert.ToUInt32(WniPART.Properties["MaxCapacity"].Value);
//                UInt32 SizeinMB = SizeinKB / 1024;
//                UInt32 SizeinGB = SizeinMB / 1024;
            }

            var dueTime = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
            timer = new Timer(state => WriteMetric(), null, 0, dueTime);
        }

        public void StopCollecting()
        {
            timer.Dispose();
            timer = null;
        }
    }
}
