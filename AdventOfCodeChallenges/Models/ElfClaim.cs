namespace AdventOfCodeChallenges.Models
{
    public class ElfClaim
    {
        public int Id { get; }
        public int Left { get; }
        public int Top { get; }
        public int Width { get; }
        public int Height { get; }

        public ElfClaim(string claim)
        {
            var elements = claim.Split(' ');

            Id = int.Parse(elements[0].Remove(0, 1));

            var position = elements[2].Remove(elements[2].Length - 1).Split(',');
            Left = int.Parse(position[0]);
            Top = int.Parse(position[1]);

            var size = elements[3].Split('x');
            Width = int.Parse(size[0]);
            Height = int.Parse(size[1]);
        }
    }
}
