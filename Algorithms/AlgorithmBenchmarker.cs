using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using algorithm_benchmarks.Extras;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Running;


public class Config : ManualConfig
{
    public Config()
    {
        AddExporter(CsvMeasurementsExporter.Default);
        AddExporter(RPlotExporter.Default);
    }
}

[MemoryDiagnoser]
[MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvMeasurementsExporter, RPlotExporter]
[Config(typeof(Config))]
public partial class AlgorithmBenchmarker
{
    // Fetches a list of values from the config file to run the benchmark with
    // different sizes of the DataList
    [ParamsSource(nameof(ValuesForDataSize))]
    public string DataSize;
    public IEnumerable<string> ValuesForDataSize => ConfigurationManager.AppSettings["DataSizes"].Split(',');
    private int[] data;

    // GlobalSetup Attribute initializes the data once for each method.
    [GlobalSetup]
    public void Setup()
    {
        int value;
        if (int.TryParse(DataSize, out value))
        {
            data = GenerateData(value);
        }
        else
        {
            string compare = DataSize.Trim().ToLower();
            var split = compare.Split('=');
            bool isInt = int.TryParse(split[1], out value);
            if (compare.Contains(SortingType.reverse.ToString()))
            {
                if (isInt)
                {
                    data = GenerateDataReverse(value);
                }
            } 
            else if (compare.Contains(SortingType.last_lowest.ToString()))
            {
                if (isInt)
                {
                    data = GenerateDataLastLowest(value);
                }
            }
        }
    }

    // The method to populate the data with random values
    int[] GenerateData(int size)
    {
        Random rnd = new Random();
        int[] data = new int[size];

        for (int i = 0; i < data.Length; i++)
            data[i] = rnd.Next(size);

        return data;
    }

    // Generate a list with all the values in reverse order. Quicksort worst case scenario
    int[] GenerateDataReverse(int size)
    {
        int[] data = new int[size];
        int startValue = size;
        for (int i = 0; i < data.Length; i++)
            data[i] = startValue--;

        return data;
    }

    // Generate a list where the last value is the lowest. Insertion sort worst case scenario
    int[] GenerateDataLastLowest(int size)
    {
        int[] data = new int[size];
        data = GenerateData(size);
        data[size-1] = 0;
        return data;
    }
}