using System.Text.RegularExpressions;

namespace AoC.Day03
{
    internal static class MultiplicationFinder
    {
        public static async Task<int> Multiply()
        {
            var content = await File.ReadAllTextAsync("Day03/input.txt");
            return Multiply(content);
        }

        public static async Task<int> MultiplyWithConditions()
        {
            var content = await File.ReadAllTextAsync("Day03/input.txt");
            var substrings = content.Split("don't()").ToList();

            var first = substrings.First();
            substrings.RemoveAt(0);

            var result = Multiply(first);

            foreach (var substring in substrings)
            {
                var splitted = substring.Split("do()").ToList();
                splitted.RemoveAt(0);

                foreach (var line in splitted)
                {
                    result += Multiply(line);
                }
            }

            return result;
        }

        private static int Multiply(string content)
        {
            var regex = RegexUtilities.MatchMultiplications();

            var result = 0;

            foreach (Match match in regex.Matches(content))
            {
                if (match.Success)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);

                    result += x * y;
                }
            }

            return result;
        }
    }
}
