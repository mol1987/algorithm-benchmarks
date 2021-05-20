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
            //int[] data;
            //AlgorithmBenchmarker foo = new AlgorithmBenchmarker();
            //data = foo.GenerateData(100);
            //foo.DisplayArray(data);
            //Console.WriteLine();
            //Console.WriteLine();


            //var time24 = DateTime.Now;
            //foo.QuickSort(data, 0, data.Length - 1);

            //foo.DisplayArray(data);
            //Console.WriteLine("\nelapsed time(QuickSort): " + (time24 - DateTime.Now));
            //Console.WriteLine();



            //data = foo.GenerateData(100);
            //foo.DisplayArray(data);
            //time24 = DateTime.Now;
            //foo.BubbleSort(data);
            //Console.WriteLine();
            //foo.DisplayArray(data);
            //Console.WriteLine("\nelapsed time(bubble): " + (time24 - DateTime.Now));
            //Console.WriteLine();



            //data = foo.GenerateDataReverse(100);
            //foo.DisplayArray(data);
            //Console.WriteLine();
            //Console.WriteLine();

            //time24 = DateTime.Now;
            //foo.QuickSort(data, 0, data.Length - 1);

            //foo.DisplayArray(data);
            //Console.WriteLine("\nelapsed time(QuickSortreverse): " + (time24 - DateTime.Now));
            //Console.WriteLine();

            //data = foo.GenerateDataLastLowest(100);
            //foo.DisplayArray(data);
            //Console.WriteLine();
            //Console.WriteLine();

            //time24 = DateTime.Now;
            //foo.BubbleSort(data);
            //foo.DisplayArray(data);

            //Console.WriteLine("\nelapsed time(bubblelast): " + (time24 - DateTime.Now));
            //Console.WriteLine();
        }
    }
}