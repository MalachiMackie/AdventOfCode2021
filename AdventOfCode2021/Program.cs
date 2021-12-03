using AdventOfCode2021.Day1;

const string template = "Day {0} Part {1}: {2}\n-------------------------";

Console.WriteLine(template, 1, 1, await Problem.SolvePart1());
Console.WriteLine(template, 1, 2, await Problem.SolvePart2());
Console.WriteLine(template, 2, 1, await AdventOfCode2021.Day2.Problem.SolvePart1());
Console.WriteLine(template, 2, 2, await AdventOfCode2021.Day2.Problem.SolvePart2());