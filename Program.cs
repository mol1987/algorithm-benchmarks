using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

namespace MyBenchmarks
{
    public class Program
    {
        // Convert a value from the config file to a appropriate TimeUnit object
        static TimeUnit tUnit 
        {
            get 
            {
                switch (ConfigurationManager.AppSettings["TimeUnit"].ToLower())
                {
                    case "nanosecond":
                        return TimeUnit.Nanosecond;
                    case "microsecond":
                        return TimeUnit.Microsecond;
                    case "millisecond":
                        return TimeUnit.Millisecond;
                    case "second":
                        return TimeUnit.Second;
                    case "minute":
                        return TimeUnit.Minute;
                    case "hour":
                        return TimeUnit.Hour;
                    case "day":
                        return TimeUnit.Day;
                    default:
                        return TimeUnit.Microsecond;
                }
            }
        }

        // Convert a value from the config file to a appropriate SizeUnit object
        static SizeUnit sUnit
        {
            get
            {
                switch (ConfigurationManager.AppSettings["SizeUnit"].ToLower())
                {
                    case "b":
                        return SizeUnit.B;
                    case "kb":
                        return SizeUnit.KB;
                    case "mb":
                        return SizeUnit.MB;
                    case "gb":
                        return SizeUnit.GB;
                    case "tb":
                        return SizeUnit.TB;
                    default:
                        return SizeUnit.KB;
                }
            }
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<AlgorithmBenchmarker>(
                    ManualConfig.Create(DefaultConfig.Instance).WithSummaryStyle(
                            new SummaryStyle(
                                null, 
                                true,
                                sUnit, 
                                tUnit
                                )
                        ));
            
        }
    }
}