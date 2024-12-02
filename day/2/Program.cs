// https://adventofcode.com/2024/day/1
// part 1
var input = File.ReadAllText("input.txt");
var safeCount = 0;
var reports = input.Split('\n');
foreach (var report in reports)
{
    var reportNumbers = report.Split(' ').Select(int.Parse).ToList();
    var initialDiff = reportNumbers[1] - reportNumbers[0];
    if (initialDiff == 0)
    {
        continue;
    }
    var notSafe = false;
    for (int i = 1; i < reportNumbers.Count; i++)
    {
        var currentDiff = reportNumbers[i] - reportNumbers[i - 1];
        if (currentDiff < 0 && initialDiff > 0 || currentDiff > 0 && initialDiff < 0)
        {
            notSafe = true;
            break;
        }
        if (Math.Abs(currentDiff) < 1 || Math.Abs(currentDiff) > 3)
        {
            notSafe = true;
        }
    }
    if (!notSafe)
    {
        safeCount++;
    }
}
Console.WriteLine("Safe count:" + safeCount);