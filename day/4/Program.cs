// https://adventofcode.com/2024/day/4
// part 1
var input = File.ReadAllText("input.txt");
var lines = input.Split("\n");
var count = 0;
var word = "XMAS";
var coordinates = new[] {
    new Tuple<int, int>(-1, -1), new Tuple<int, int>(0, -1), new Tuple<int, int>(1, -1),
    new Tuple<int, int>(-1, 0), new Tuple<int, int>(1, 0),
    new Tuple<int, int>(-1, 1), new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 1)
};

for (var y = 0; y < lines.Length; y++)
{
    for (var x = 0; x < lines[0].Length; x++)
    {
        count += FindWord(x, y, lines, word);
    }
}

Console.WriteLine("Word count: " + count);

int FindWord(int x, int y, string[] lines, string word)
{
    if (lines[y][x] != word[0])
    {
        return 0;
    }
    var count = 0;
    foreach (var coordinate in coordinates)
    {
        if (IsWord(x, y, lines, word.Substring(1), coordinate))
        {
            count++;
        }
    }
    return count;
}

bool IsWord(int x, int y, string[] lines, string word, Tuple<int, int> coordinate)
{
    if (word.Length == 0)
    {
        return true;
    }
    var newX = x + coordinate.Item1;
    var newY = y + coordinate.Item2;
    if (newX < 0 || newX >= lines[0].Length || newY < 0 || newY >= lines.Length)
    {
        return false;
    }
    if (lines[newY][newX] != word[0])
    {
        return false;
    }
    return IsWord(newX, newY, lines, word.Substring(1), coordinate);
}