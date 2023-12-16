namespace advent_of_code.one;

public static class Trebuchet {
    private static readonly FileInput F = new ("./inputs/three.txt");

    public static void Run() {
        Console.WriteLine("Advent of Code 2023 Day 1: Trebuchet");
        
        string[] numberStrings = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"};
        Dictionary<string, char> numberLookup = new() {
            { "zero", '0' },
            { "one", '1' },
            { "two", '2' },
            { "three", '3' },
            { "four", '4' },
            { "five", '5' },
            { "six", '6' },
            { "seven", '7' },
            { "eight", '8' },
            { "nine", '9' }
        };

        var sum = 0;
        var sumWithStrings = 0;
        List<int> calibrators = new List<int>();
        List<int> calibratorsWithStrings = new List<int>();
        Console.WriteLine($"{F.Lines.Length} loaded");
        foreach (var line in F.Lines) {
            List<char> numbers = new List<char>();
            List<char> numbersWithStrings = new List<char>();
            for (var i = 0; i < line.Length; i++) {
                var c = line[i];
                if (char.IsDigit(c)) {
                    numbers.Add(c); 
                    numbersWithStrings.Add(c);
                }
                if (char.IsLetter(c)) {
                    foreach (var n in numberStrings) {
                        if (i+n.Length <= line.Length && line.Substring(i, n.Length).Equals(n)) {
                            numbersWithStrings.Add(numberLookup[n]);
                            break;
                        }
                    }
                }
            }
            if (numbers.Count >= 1) calibrators.Add(int.Parse(new string(new [] {numbers[0], numbers[^1]})));
            if (numbersWithStrings.Count >= 1) calibratorsWithStrings.Add(int.Parse(new string(new [] {numbersWithStrings[0], numbersWithStrings[^1]})));
            // Console.WriteLine($"{line}: {(numbers.Count >= 1 ? new string(new[] { numbers[0], numbers[^1] }) : "")}");
            // Console.WriteLine($"{line}: {(numbersWithStrings.Count >= 1 ? new string(new[] { numbersWithStrings[0], numbersWithStrings[^1] }) : "")}");
        }

        foreach (var c in calibrators) sum += c;
        foreach (var c in calibratorsWithStrings) sumWithStrings += c;
        
        Console.WriteLine($"Sum (pt. 1): {sum}");
        Console.WriteLine($"Sum (pt. 2): {sumWithStrings}");
    }
}