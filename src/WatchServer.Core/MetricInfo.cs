namespace WatchServer.Core
{
    using System;

    public struct MetricInfo {
        public MetricInfo(MetricCode code, DateTime time)
        {
            this.Code = code;
            this.Time = time;
        }

        public MetricCode Code { get; }
        public DateTime Time { get; }
        public override int GetHashCode()
        {
            return this.Code.GetHashCode() * 17 + this.Time.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj != null && obj is MetricInfo && this.GetHashCode() == obj.GetHashCode();
        }

        private static int Compare(MetricInfo metricInfo1, MetricInfo metricInfo2)
        {
            if (metricInfo1.Code == metricInfo2.Code)
            {
                if (metricInfo1.Time < metricInfo2.Time)
                {
                    return -1;
                }
                if (metricInfo1.Time == metricInfo2.Time)
                {
                    return 0;
                }
                if (metricInfo1.Time > metricInfo2.Time)
                {
                    return 1;
                }
                return 0;
            }
            if (metricInfo1.Code < metricInfo2.Code)
            {
                return -1;
            }
            if (metricInfo1.Code == metricInfo2.Code)
            {
                return 0;
            }
            if (metricInfo1.Code > metricInfo2.Code)
            {
                return 1;
            }
            return 0;
        }

        public static bool operator >(MetricInfo metricInfo1, MetricInfo metricInfo2)
        {
            return Compare(metricInfo1, metricInfo2) > 0;
        }
        public static bool operator >=(MetricInfo metricInfo1, MetricInfo metricInfo2)
        {
            return Compare(metricInfo1, metricInfo2) >= 0;
        }

        public static bool operator <(MetricInfo metricInfo1, MetricInfo metricInfo2)
        {
            return Compare(metricInfo1, metricInfo2) < 0;
        }
        public static bool operator <=(MetricInfo metricInfo1, MetricInfo metricInfo2)
        {
            return Compare(metricInfo1, metricInfo2) <= 0;
        }
    }
}