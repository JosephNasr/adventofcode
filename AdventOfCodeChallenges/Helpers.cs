using System.Collections.Generic;

namespace AdventOfCodeChallenges
{
    public static class Helpers
    {
        public static int GetDifferentiatingIndex(string first, string second)
        {
            var index = -1;
            var differentCharacters = 0;

            for (var i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    if (++differentCharacters > 1)
                    {
                        return -1;
                    }

                    index = i;
                }
            }

            return index;
        }

        private static void AddValueInGrid(Dictionary<int, Dictionary<int, bool>> grid, int leftPosition, int topPosition)
        {
            if (!grid.ContainsKey(leftPosition))
            {
                grid[leftPosition] = new Dictionary<int, bool> { { topPosition, false } };
            }
            else if (!grid[leftPosition].ContainsKey(topPosition))
            {
                grid[leftPosition][topPosition] = false;
            }
            else
            {
                grid[leftPosition][topPosition] = true;
            }
        }

        public static void AddClaimValues(this Dictionary<int, Dictionary<int, bool>> grid, int leftPosition, int topPosition, int width, int height)
        {
            for (var leftIndex = leftPosition; leftIndex < leftPosition + width; leftIndex++)
            {
                for (var topIndex = topPosition; topIndex < topPosition + height; topIndex++)
                {
                    AddValueInGrid(grid, leftIndex, topIndex);
                }
            }
        }
    }
}
