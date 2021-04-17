using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyBenchmarks
{
    public class Program
    {
        [MemoryDiagnoser]
        public class MemoryBenchmarkerDemo
        {
            int NumberOfItems = 100;
            [Benchmark]
            public string ConcatStringsUsingStringBuilder()
            {
                var sb = new StringBuilder();
                for (int i = 0; i < NumberOfItems; i++)
                {
                    sb.Append("Hello World!" + i);
                }
                return sb.ToString();
            }
            [Benchmark]
            public string ConcatStringsUsingGenericList()
            {
                var list = new List<string>(NumberOfItems);
                for (int i = 0; i < NumberOfItems; i++)
                {
                    list.Add("Hello World!" + i);
                }
                return list.ToString();
            }
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<AlgorithmBenchmarker>();
        }
    }
}