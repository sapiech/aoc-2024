using System.Text.RegularExpressions;

namespace AoC.Day03;

public static partial class RegexUtilities
{
    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)", RegexOptions.Compiled)]
    public static partial Regex MatchMultiplications();
}
