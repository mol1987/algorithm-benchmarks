using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public partial class AlgorithmBenchmarker
{
            int NumberOfItems = 100;
            static int DataSize = 1000;

            int[] GenerateData(int size)
            {
                Random rnd = new Random();
                int[] data = new int[size];

                for (int i = 0; i < data.Length; i++)
                    data[i] = rnd.Next(data.Length);

                return data;
            }
}