namespace AdventOfCodeChallenges.Models
{
    public class ElfClaim
    {
        public int Id { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

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
