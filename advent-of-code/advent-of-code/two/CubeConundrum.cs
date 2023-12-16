namespace advent_of_code.two; 

public static class CubeConundrum {
	private static readonly FileInput F = new ("./inputs/three.txt");
	private const int MaxRed = 12;
	private const int MaxGreen = 13;
	private const int MaxBlue = 14;

	public static void Run() {
		Console.WriteLine("Advent of Code 2023 Day 2: Cube Conundrum");
		Console.WriteLine($"{F.Lines.Length} loaded");
		var sum = 0;
		var powerSum = 0;
		for (var i = 0; i < F.Lines.Length; i++) {
			var line = F.Lines[i];

			var suffix = line.Substring(line.IndexOf(":", StringComparison.Ordinal) + 2);
			// Console.WriteLine(suffix);
			bool impossible = false;
			var minRed = 0;
			var minGreen = 0;
			var minBlue = 0;
			string[] rounds = suffix.Split(";", StringSplitOptions.TrimEntries);
			foreach (var round in rounds) {
				string[] colors = round.Split(",", StringSplitOptions.TrimEntries);
				foreach (var color in colors) {
					string[] d = color.Split(" ");
					
					var colorCount = int.Parse(d[0]);
					
					// Part 1 Calculation
					if (d[1].Equals("red") && colorCount > MaxRed ||
					    d[1].Equals("green") && colorCount > MaxGreen ||
					    d[1].Equals("blue") && colorCount > MaxBlue) {
						impossible = true;
					};
					
					// Part 2 Calculation
					if (d[1].Equals("red")) minRed = int.Max(minRed, colorCount);
					if (d[1].Equals("green")) minGreen = int.Max(minGreen, colorCount);
					if (d[1].Equals("blue")) minBlue = int.Max(minBlue, colorCount);
				}
			}
			if (!impossible) sum += i + 1;
			// else Console.WriteLine($"Game {i + 1} Invalid");
			
			// Console.WriteLine($"Game {i + 1} Power: {minRed * minGreen * minBlue} ({minRed}x{minGreen}x{minBlue})");
			powerSum += minRed * minGreen * minBlue;
		}
		Console.WriteLine($"Sum (pt. 1): {sum}");
		Console.WriteLine($"Power Sum (pt. 2): {powerSum}");
	}
}