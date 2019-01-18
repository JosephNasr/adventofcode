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
            //Day1_First();
            //Day1_Second();
            //Day2_First();
            //Day2_Second();
            //Day3_First();
            //Day3_Second();
            Day4_First();
            Day4_Second();
            //Day5_First();
            //Day5_Second();
            //Day6_First();

            Console.ReadLine();
        }

        #region Day 1

        private static void Day1_First()
        {
            var inputFrequencies = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day1.txt"));

            var totalFrequency = inputFrequencies.Sum(frequency => int.Parse(frequency));

            Console.WriteLine($"Day 1, first:\t{totalFrequency}");
        }

        private static void Day1_Second()
        {
            var inputFrequencies = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day1.txt"));

            var frequency = 0;
            var found = false;
            //var iterations = 0;

            var previousData = new HashSet<int>();

            while (!found)
            {
                //Console.WriteLine($"Iteration #{iterations++}");

                foreach (var newFrequency in inputFrequencies)
                {
                    frequency += int.Parse(newFrequency);

                    if (previousData.Contains(frequency))
                    {
                        Console.WriteLine($"Day 1, second:\t{frequency}");
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

        #endregion

        #region Day 2

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
            Console.WriteLine($"Day 2, first:\t{result}");
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
                    Console.WriteLine($"Day 2, second:\t{result}");
                    break;
                }

                previousData.Add(id);
            }
        }

        #endregion

        #region Day 3

        private static void Day3_First()
        {
            var inputClaims = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day3.txt"));

            var grid = new Dictionary<int, Dictionary<int, int>>();

            foreach (var claim in inputClaims)
            {
                var elfClaim = new Claim(claim);
                grid.AddClaimValues(elfClaim.Left, elfClaim.Top, elfClaim.Width, elfClaim.Height);
            }

            var overlappingSquares = grid.Sum(kvp => kvp.Value.Values.Where(value => value > 1).Count());
            Console.WriteLine($"Day 3, first:\t{overlappingSquares}");
        }

        private static void Day3_Second()
        {
            var inputClaims = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day3.txt"));

            var resultId = 0;
            var grid = new Dictionary<int, Dictionary<int, int>>();

            foreach (var claim in inputClaims)
            {
                var elfClaim = new Claim(claim);
                grid.AddClaimValues(elfClaim.Left, elfClaim.Top, elfClaim.Width, elfClaim.Height);
            }

            foreach (var inputClaim in inputClaims)
            {
                var claim = new Claim(inputClaim);
                var overlapping = grid.CheckIfOverlapped(claim.Left, claim.Top, claim.Width, claim.Height);

                if (!overlapping)
                {
                    resultId = claim.Id;
                    break;
                }
            }

            Console.WriteLine($"Day 3, second:\t{resultId}");
        }

        #endregion

        #region Day 4

        private static void Day4_First()
        {
            var inputTimestamps = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day4.txt"));

            var timestamps = new List<Timestamp>();
            var sleepSchedule = new Dictionary<(int id, int minute), int>();

            inputTimestamps.ToList().ForEach(timestamp => timestamps.Add(new Timestamp(timestamp)));
            timestamps = timestamps.OrderBy(timestamp => timestamp.Time).ToList();

            var id = -1;
            var sleepStart = DateTime.MinValue;

            foreach (var timestamp in timestamps)
            {
                switch (timestamp.Action.ToLower())
                {
                    case "begins shift":
                        id = timestamp.Id;
                        break;
                    case "falls asleep":
                        sleepStart = timestamp.Time;
                        break;
                    case "wakes up":
                        sleepSchedule.AddSleepTime(id, sleepStart, timestamp.Time);
                        break;
                }
            }

            var mostSleepingPerson = sleepSchedule.GroupBy(item => item.Key.id).ToList().Select(item => item.ToList()).OrderBy(item => item.Sum(kvp => kvp.Value)).Last().OrderBy(item => item.Value).Last().Key;

            var result = mostSleepingPerson.id * mostSleepingPerson.minute;
            Console.WriteLine($"Day 4, first:\t{result}");
        }

        private static void Day4_Second()
        {
            var inputTimestamps = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day4.txt"));

            var timestamps = new List<Timestamp>();
            var sleepSchedule = new Dictionary<(int id, int minute), int>();

            inputTimestamps.ToList().ForEach(timestamp => timestamps.Add(new Timestamp(timestamp)));
            timestamps = timestamps.OrderBy(timestamp => timestamp.Time).ToList();

            var id = -1;
            var sleepStart = DateTime.MinValue;

            foreach (var timestamp in timestamps)
            {
                switch (timestamp.Action.ToLower())
                {
                    case "begins shift":
                        id = timestamp.Id;
                        break;
                    case "falls asleep":
                        sleepStart = timestamp.Time;
                        break;
                    case "wakes up":
                        sleepSchedule.AddSleepTime(id, sleepStart, timestamp.Time);
                        break;
                }
            }

            var mostFrequentMinuteSlept = sleepSchedule.OrderBy(item => item.Value).Last().Key;
            
            var result = mostFrequentMinuteSlept.id * mostFrequentMinuteSlept.minute;
            Console.WriteLine($"Day 4, second:\t{result}");
        }

        #endregion

        #region Day 5

        private static void Day5_First()
        {
            var inputData = File.ReadAllText(Path.Combine(DATA_FOLDER, "day5.txt"));

            for (var index = 0; index < inputData.Length - 1; index++)
            {
                if (Helpers.AreSameLetterButDifferentCase(inputData[index], inputData[index + 1]))
                {
                    inputData = inputData.Remove(index, 2);
                    index -= index > 0 ? 2 : 1;
                }
            }

            var result = inputData.Length;
            Console.WriteLine($"Day 5, first:\t{result}");
        }

        private static void Day5_Second()
        {
            var inputData = File.ReadAllText(Path.Combine(DATA_FOLDER, "day5.txt"));
            var shortestPolymerLength = int.MaxValue;

            for (var character = 'a'; character <= 'z'; character++)
            {
                var modifiedInput = inputData.Replace(character.ToString(), "").Replace(character.ToString().ToUpper(), "");
                var polymer = new Stack<char>();

                for (var index = 0; index < modifiedInput.Length; index++)
                {
                    if (polymer.Count > 0 && Helpers.AreSameLetterButDifferentCase(modifiedInput[index], polymer.Peek()))
                    {
                        polymer.Pop();
                    }
                    else
                    {
                        polymer.Push(modifiedInput[index]);
                    }
                }

                if (polymer.Count < shortestPolymerLength)
                {
                    shortestPolymerLength = polymer.Count;
                }
            }

            Console.WriteLine($"Day 5, second:\t{shortestPolymerLength}");
        }

        #endregion

        #region Day 6

        private static void Day6_First()
        {
            var inputCoordinates = File.ReadAllLines(Path.Combine(DATA_FOLDER, "day6.txt"));
            var data = inputCoordinates.Select(inputCoordinate => new Coordinate(inputCoordinate)).ToList();

            foreach (var inputCoordinate in inputCoordinates)
            {
                var coordinate = new Coordinate(inputCoordinate);
            }
        }

        #endregion
    }
}
