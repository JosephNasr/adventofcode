using System;

namespace AdventOfCodeChallenges.Models
{
    public class Timestamp
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Action { get; set; }

        public Timestamp(string timestamp)
        {
            var tokens = timestamp.Split(' ');

            if (tokens.Length == 6)
            {
                Id = int.Parse(tokens[3].TrimStart('#'));
                Action = string.Join(" ", tokens[4], tokens[5]);
            }
            else
            {
                Id = -1;
                Action = string.Join(" ", tokens[2], tokens[3]);
            }

            var dateString = string.Join(" ", tokens[0].TrimStart('['), tokens[1].TrimEnd(']'));
            Time = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm", null);
        }
    }
}
