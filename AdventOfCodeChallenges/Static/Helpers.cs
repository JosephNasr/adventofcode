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

        public static bool AreSameLetterButDifferentCase(char first, char second)
        {
            if (first == second)
            {
                return false;
            }

            var firstStr = first.ToString();
            var secondStr = second.ToString();

            return firstStr == secondStr.ToUpper() || firstStr.ToUpper() == secondStr;
        }
    }
}
