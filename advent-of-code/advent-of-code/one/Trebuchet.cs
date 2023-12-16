namespace advent_of_code.one;

public static class Trebuchet {
    private static readonly FileInput F = new ("./inputs/three.txt");

    public static void Run() {
        Console.WriteLine("Advent of Code 2023 Day 1: Trebuchet");
        
        string[] numberStrings = new [] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"};
        Dictionary<string, char> numberLookup = new Dictionary<string, char>();
        numberLookup.Add("zero", '0');
        numberLookup.Add("one", '1');
        numberLookup.Add("two", '2');
        numberLookup.Add("three", '3');
        numberLookup.Add("four", '4');
        numberLookup.Add("five", '5');
        numberLookup.Add("six", '6');
        numberLookup.Add("seven", '7');
        numberLookup.Add("eight", '8');
        numberLookup.Add("nine", '9');
        
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