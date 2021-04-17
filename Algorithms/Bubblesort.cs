using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public partial class AlgorithmBenchmarker
{
            [Benchmark]
            public void BubbleSortRun() {
                int[] data = GenerateData(DataSize);
                BubbleSort(data);
            }

            public void BubbleSort(int[] data)
            {
                bool needsSorting = true;
                //Gör en loop för varje tal som skall sorteras, avbryt om talen är sorterade
                for (int i = 0; i < data.Length - 1 && needsSorting; i++)
                {
                    //Signalera att vi börjar om en ny vända med sortering
                    needsSorting = false;
                    //Gå igenom alla tal fram till och med de tal som ev. 
                    //redan är sorterade (variabeln i)
                    for (int j = 0; j < data.Length - 1 - i; j++)
                    {
                        //Flytta större tal fram i vektorn
                        if (data[j] > data[j + 1])
                        {
                            //Signalera att vi kommer att behöva fortsätta sortera
                            needsSorting = true;
                            //Byt plats på tal
                            int tmp = data[j +1];
                            data[j + 1] = data[j];
                            data[j] = tmp;
                        }
                    }
                    //Har vi nu inte behövt sortera några tal så är 
                    //needsSorting == false och loop'en kommer att avbrytas
                }
            }
}