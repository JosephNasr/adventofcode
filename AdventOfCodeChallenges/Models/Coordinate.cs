using System;

namespace AdventOfCodeChallenges.Models
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(string input)
        {
            var tokens = input.Split(new string[] { ", " }, StringSplitOptions.None);

            X = int.Parse(tokens[0]);
            Y = int.Parse(tokens[1]);
        }

        public int GetDistanceTo(Coordinate coordinate)
        {
            return Math.Abs(coordinate.X - X) + Math.Abs(coordinate.Y - Y);
        }
    }
}
