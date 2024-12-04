using System.Text.RegularExpressions;

namespace AoC.Day04;

public static partial class RegexUtilities
{
    [GeneratedRegex(@"XMAS|SAMX", RegexOptions.Compiled)]
    public static partial Regex MatchWord();
}
