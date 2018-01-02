using WatchServer.Core;

namespace Collector.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class MetricInfoTests
    {
        [TestClass]
        public class WhenCheckLessThan
        {
            [TestMethod]
            public void ThenShouldReturnTrueGivenSameCodeButLessDateTime()
            {
                //arrange
                var metricInfo1 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 16));
                var metricInfo2 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 17));

                //act
                var result = metricInfo1 < metricInfo2;

                //assert
                Assert.IsTrue(result);
            }
            [TestMethod]
            [DataRow(17)]
            [DataRow(18)]
            public void ThenShouldReturnFalseGivenSameCodeButGreaterOrEqualDateTime(int day)
            {
                //arrange
                var metricInfo1 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, day));
                var metricInfo2 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 17));

                //act
                var result = metricInfo1 < metricInfo2;

                //assert
                Assert.IsFalse(result);
            }
        }

        [TestClass]
        public class WhenCheckEquals
        {
            [TestMethod]
            public void ThenShouldReturnFalseGivenDifferentCodeSameTime()
            {
                //arrange
                var metricInfo1 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 17));
                var metricInfo2 = new MetricInfo(MetricCode.PercentRAM, new DateTime(2017, 12, 17));

                //act
                var result = metricInfo1.Equals(metricInfo2);
                var result2 = metricInfo1.GetHashCode() == metricInfo2.GetHashCode();

                //assert
                Assert.IsFalse(result);
                Assert.IsFalse(result2);
            }
            [TestMethod]
            public void ThenShouldReturnTrueGivenSameInputs()
            {
                //arrange
                var metricInfo1 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 17));
                var metricInfo2 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 17));

                //act
                var result = metricInfo1.Equals(metricInfo2);

                //assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void ThenShouldReturnFalseGivenNull()
            {
                //arrange
                var metricInfo = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 17));

                //act
                var result = metricInfo.Equals(null);

                //assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void ThenShouldReturnFalseGivenDifferentInputs()
            {
                //arrange
                var metricInfo1 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 17));
                var metricInfo2 = new MetricInfo(MetricCode.PercentCPU, new DateTime(2017, 12, 15));

                //act
                var result = metricInfo1.Equals(metricInfo2);

                //assert
                Assert.IsFalse(result);
            }
        }
    }
}