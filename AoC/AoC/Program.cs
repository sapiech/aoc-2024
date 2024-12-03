using AoC.Day01;
using AoC.Day02;
using AoC.Day03;

//var day1part1 = await DistanceMeter.Meter();
//Console.WriteLine($"Total distance between lists is: {day1part1}.");

//var day1part2 = await DistanceMeter.MeterSimilarityScore();
//Console.WriteLine($"Sum of all similarity score is: {day1part2}.");

//var day2part1 = await ReportChecker.CheckReports(false);
//Console.WriteLine($"Total count of the safe reports is: {day2part1}.");

//var day2part2 = await ReportChecker.CheckReports(true);
//Console.WriteLine($"Total count of the safe reports handled by Problem Dampener is: {day2part2}.");

var day3part1 = await MultiplicationFinder.Multiply();
Console.WriteLine($"Multiplication result is: {day3part1}.");

var day3part2 = await MultiplicationFinder.MultiplyWithConditions();
Console.WriteLine($"Multiplication result is: {day3part2}.");

