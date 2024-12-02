// https://adventofcode.com/2024/day/1
// part 1
var input = File.ReadAllText("input.txt");
var safeCount = 0;
var reports = input.Split('\n');
foreach (var report in reports)
{
    var reportNumbers = report.Split(' ').Select(int.Parse).ToList();
    
    if (IsSafe(reportNumbers))
    {
        safeCount++;
    } else {
        //part 2
        for(int i = 0; i < reportNumbers.Count; i++) {
            var reportCopy = reportNumbers.ToList();
            reportCopy.RemoveAt(i);
            if(IsSafe(reportCopy)){
                safeCount++;
                break;
            }
        }
    }
}
Console.WriteLine("Safe count:" + safeCount);

bool IsSafe(List<int> reportNumbers){
    var initialDiff = reportNumbers[1] - reportNumbers[0];
    if (initialDiff == 0)
    {
        return false;
    }
    for (int i = 1; i < reportNumbers.Count; i++)
    {
        var currentDiff = reportNumbers[i] - reportNumbers[i - 1];
        if (currentDiff < 0 && initialDiff > 0 || currentDiff > 0 && initialDiff < 0)
        {
            return false;
        }
        if (Math.Abs(currentDiff) < 1 || Math.Abs(currentDiff) > 3)
        {
            return false;
        }
    }
    return true;
}