// https://adventofcode.com/2024/day/3
// part 1
var input = File.ReadAllText("input.txt");
var regex = new System.Text.RegularExpressions.Regex(@"mul\(\d+,\d+\)");
var matches = regex.Matches(input);
var sum = 0;
foreach (var match in matches)
{
    var numbers = match.ToString().Substring(4, match.ToString().Length - 5).Split(',').Select(int.Parse).ToList();
    sum += numbers[0] * numbers[1];
}

Console.WriteLine("Total sum: " + sum);