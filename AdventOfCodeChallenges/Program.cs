using AdventOfCodeChallenges.Models;
using AdventOfCodeChallenges.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeChallenges
{
    public class Program
    {
        private const string DATA_FOLDER = @"..\..\Data";

        public static void Main(string[] args)
        {
            Day3_First();

            Console.ReadKey(true);
        }

        private static void Day1_Second()
        {
            var inputFrequencies = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day1.txt"));

            var frequency = 0;
            var found = false;
            var iterations = 0;

            var previousData = new HashSet<int>();

            while (!found)
            {
                Console.WriteLine($"Iteration #{iterations++}");

                foreach (var newFrequency in inputFrequencies)
                {
                    frequency += int.Parse(newFrequency);

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
            var inputIds = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day2.txt"));

            var twoCounter = 0;
            var threeCounter = 0;

            foreach (var id in inputIds)
            {
                var frequencies = new Dictionary<char, int>();

                for (var index = 0; index < id.Length; index++)
                {
                    var letter = id[index];

                    if (!frequencies.ContainsKey(letter))
                    {
                        frequencies[letter] = 1;
                    }
                    else
                    {
                        frequencies[letter]++;
                    }
                }

                if (frequencies.ContainsValue(2))
                {
                    twoCounter++;
                }

                if (frequencies.ContainsValue(3))
                {
                    threeCounter++;
                }
            }

            var result = twoCounter * threeCounter;
            Console.WriteLine($"Result = {result}");
        }

        private static void Day2_Second()
        {
            var inputIds = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day2.txt"));

            var previousData = new HashSet<string>();

            foreach (var id in inputIds)
            {
                var result = "";

                foreach (var previousId in previousData)
                {
                    var index = Helpers.GetDifferentiatingIndex(id, previousId);

                    if (index != -1)
                    {
                        result = id.Remove(index, 1);
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine($"Result = {result}");
                    break;
                }

                previousData.Add(id);
            }
        }

        private static void Day3_First()
        {
            var inputClaims = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day3.txt"));

            var grid = new Dictionary<int, Dictionary<int, bool>>();

            foreach (var claim in inputClaims)
            {
                var elfClaim = new ElfClaim(claim);
                grid.AddClaimValues(elfClaim.Left, elfClaim.Top, elfClaim.Width, elfClaim.Height);
            }

            var overlappingSquares = grid.Sum(kvp => kvp.Value.Values.Where(value => value).Count());
            Console.WriteLine($"Result = {overlappingSquares}");
        }
    }
}
