using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static List<string> GetSource(int count)
        {
            string[] prefixes = {
                "0113 496 0",
                "0114 496 0",
                "0115 496 0",
                "0116 496 0",
                "0117 496 0",
                "0118 496 0",
                "0121 496 0",
                "0131 496 0",
                "0141 496 0",
                "0151 496 0",
                "0161 496 0",
                "020 7946 0",
                "0191 498 0",
                "028 9649 6",
                "029 2018 0",
                "01632 960",
                "07700 900",
                "08081 570",
                "0909 8790",
                "03069 990",
            };

            List<string> permutations = new List<string>();

            foreach (string prefix in prefixes)
            {
                for (int i = 0; i < 1000; i++)
                {
                    permutations.Add(prefix + Convert.ToString(i).PadLeft(4, '0'));
                }
            }

            List<string> output = new List<string>();

            for (int i = 0; i < count; i++)
            {
                output.Add(permutations[new Random().Next(permutations.Count)]);
            }

            return output;
        }

        static void Run(String Pat, String Source)
        {
            List<int> result = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();

            result = HP.FindAll(Pat, Source);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        static void Main(int sourceLength, int patLength)
        {
            List<string> listSource = GetSource(sourceLength);
            String Source = String.Join(Environment.NewLine, listSource);
            int index = new Random().Next(sourceLength - patLength);
            String Pat = String.Join(Environment.NewLine, listSource.GetRange(index, patLength));
            Run(Source, Pat);
        }
        static void Main(string[] args)
        {
            int[] sourceLengths = {100, 1000, 10000, 100000, 1000000};
            int[] patLengths = {1, 3, 5, 7, 11};

            foreach (int sourceLength in sourceLengths)
            {
                foreach (int patLength in patLengths)
                {
                    Console.Write("{0}\t\t{1}\t\t", sourceLength, patLength);
                    Main(sourceLength, patLength);
                }
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
