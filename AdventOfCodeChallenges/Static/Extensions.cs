using System.Collections.Generic;

namespace AdventOfCodeChallenges.Static
{
    public static class Extensions
    {
        public static void AddClaimValues(this Dictionary<int, Dictionary<int, bool>> grid, int leftPosition, int topPosition, int width, int height)
        {
            for (var leftIndex = leftPosition; leftIndex < leftPosition + width; leftIndex++)
            {
                for (var topIndex = topPosition; topIndex < topPosition + height; topIndex++)
                {
                    grid.AddClaimValue(leftIndex, topIndex);
                }
            }
        }

        private static void AddClaimValue(this Dictionary<int, Dictionary<int, bool>> grid, int leftPosition, int topPosition)
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
    }
}
