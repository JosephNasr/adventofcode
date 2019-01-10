﻿using System.Collections.Generic;

namespace AdventOfCodeChallenges.Static
{
    public static class Extensions
    {
        public static void AddClaimValues(this Dictionary<int, Dictionary<int, int>> grid, int leftPosition, int topPosition, int width, int height)
        {
            for (var leftIndex = leftPosition; leftIndex < leftPosition + width; leftIndex++)
            {
                for (var topIndex = topPosition; topIndex < topPosition + height; topIndex++)
                {
                    grid.AddClaimValue(leftIndex, topIndex);
                }
            }
        }

        private static void AddClaimValue(this Dictionary<int, Dictionary<int, int>> grid, int leftPosition, int topPosition)
        {
            if (!grid.ContainsKey(leftPosition))
            {
                grid[leftPosition] = new Dictionary<int, int> { { topPosition, 1 } };
            }
            else if (!grid[leftPosition].ContainsKey(topPosition))
            {
                grid[leftPosition][topPosition] = 1;
            }
            else
            {
                grid[leftPosition][topPosition]++;
            }
        }
    }
}
