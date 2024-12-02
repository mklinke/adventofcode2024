// https://adventofcode.com/2024/day/1
// part 1
var input = File.ReadAllText("input.txt");
var lines = input.Split('\n');
var leftList = new List<int>();
var rightList = new List<int>();
foreach (var line in lines)
{
    var values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    leftList.Add(int.Parse(values[0]));
    rightList.Add(int.Parse(values[1]));
}
leftList.Sort();
rightList.Sort();
var sum = 0;
for (int i = 0; i < leftList.Count; i++) {
    var left = leftList[i];
    var right = rightList[i];
    sum += Math.Abs(left - right);
}

Console.WriteLine("Total distance: " + sum);

//part 2
var totalScore = 0;
for(int i=0; i < leftList.Count; i++) {
    var left = leftList[i];
    var occurrences = rightList.Count(n => n == left);
    var score = left * occurrences;
    totalScore += score;
}

Console.WriteLine("Total score: " + totalScore);