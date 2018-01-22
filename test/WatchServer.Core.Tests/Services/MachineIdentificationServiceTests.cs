using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WatchServer.Core.Tests.Services
{
    [TestClass]
    public class MachineIdentificationServiceTests
    {
        [TestClass]
        public class MachineIdentificationMethodComparisons
        {
            [TestMethod]
            public void WhenGetMachineNameThenShouldBeFastInCaseA()
            {
                var watch = new Stopwatch();
                var machineNameEveryTime = EnvironmentMachineNameEveryTime(watch, 500);
                var cacheRecord = CacheEnvironmentMachineName(watch, 500);


                Assert.IsTrue(cacheRecord.Elapsed < machineNameEveryTime.Elapsed);
                Assert.IsTrue(machineNameEveryTime.Object.Count == 500);
                Assert.IsTrue(cacheRecord.Object.Count == 500);
                Console.WriteLine("Cached Results in: {0}ms", cacheRecord.Elapsed);
                Console.WriteLine("Repeat Call Results in: {0}ms", machineNameEveryTime.Elapsed);
            }
            [TestMethod]
            public void WhenGetMachineNameThenShouldBeFastInCaseB()
            {
                var watch = new Stopwatch();
                var cacheEnvironmentMachineName = CacheEnvironmentMachineName(watch, 500);
                var machineNameEveryTime = EnvironmentMachineNameEveryTime(watch, 500);


                Assert.IsTrue(machineNameEveryTime.Elapsed > cacheEnvironmentMachineName.Elapsed);
                Assert.IsTrue(machineNameEveryTime.Object.Count == 500);
                Assert.IsTrue(cacheEnvironmentMachineName.Object.Count == 500);
                Console.WriteLine("Cached Results in: {0}ms", cacheEnvironmentMachineName.Elapsed);
                Console.WriteLine("Repeat call Results in: {0}ms", machineNameEveryTime.Elapsed);
            }

            private class OutputModel<T>
            {
                public OutputModel(T @object, TimeSpan elapsed)
                {
                    Object = @object;
                    Elapsed = elapsed;
                }
                public T Object { get; }
                public TimeSpan Elapsed { get; }
            }

            private static OutputModel<List<string>> CacheEnvironmentMachineName(Stopwatch watch, int loops)
            {
                watch.Reset();
                watch.Start();
                var listOfMachineNamesB = new List<string>();
                string machineName = null;
                for (var i = 0; i < loops; i++)
                {
                    if (string.IsNullOrEmpty(machineName))
                    {
                        machineName = Environment.MachineName;
                    }

                    listOfMachineNamesB.Add(machineName);
                }

                watch.Stop();
                return new OutputModel<List<string>>(listOfMachineNamesB, watch.Elapsed);
            }

            private static OutputModel<List<string>> EnvironmentMachineNameEveryTime(Stopwatch watch, int loops)
            {
                watch.Start();
                var listOfMachineNamesA = new List<string>();
                for (int i = 0; i < loops; i++)
                {
                    listOfMachineNamesA.Add(Environment.MachineName);
                }

                watch.Stop();

                var elapsedARecord = watch.Elapsed;
                return new OutputModel<List<string>>(listOfMachineNamesA, elapsedARecord);
            }
        }

    }
}
