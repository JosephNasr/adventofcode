using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeChallenges
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Day1_Second();

            Console.ReadKey(true);
        }

        private static void Day1_Second()
        {
            var inputFrequencies = File.ReadAllLines(@"..\..\Data\day1.txt");

            var frequency = 0;
            var found = false;
            var iterations = 0;

            var previousData = new HashSet<int>();

            while (!found)
            {
                Console.WriteLine($"Iteration #{iterations++}");

                foreach (var newFrequency in inputFrequencies)
                {
                    frequency += Int32.Parse(newFrequency);

                    if (previousData.Contains(frequency))
                    {
                        Console.WriteLine($"First duplicate: {frequency}");
                        found = true;
                        break;
                    }
                    else
                    {
                        previousData.Add(frequency);
                    }
                }
            }
        }

        private static void Day2_First()
        {
            var inputIds = File.ReadAllText(@"..\..\Data\day2.txt");

            foreach (var id in inputIds)
            {

            }
        }
    }
}
