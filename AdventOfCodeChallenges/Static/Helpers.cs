namespace AdventOfCodeChallenges.Static
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
    }
}
