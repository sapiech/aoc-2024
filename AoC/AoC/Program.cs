using AoC.Day01;

var day1part1 = await DistanceMeter.Meter();
Console.WriteLine($"Total distance between lists is: {day1part1}.");

var day1part2 = await DistanceMeter.MeterSimilarityScore();
Console.WriteLine($"Sum of all similarity score is: {day1part2}.");
