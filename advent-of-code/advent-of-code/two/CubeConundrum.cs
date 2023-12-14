namespace advent_of_code.two; 

public static class CubeConundrum {
	private static readonly FileInput F = new ("./two/input.txt");

	public static void Run() {
		Console.WriteLine("Advent of Code 2023 Day 2: Cube Conundrum");
		Console.WriteLine($"{F.Lines.Length} loaded");
		foreach (var line in F.Lines) {
			var redCount = 0;
			var greenCount = 0;
			var blueCount = 0;
			
			var suffix = line.Substring(line.IndexOf(":", StringComparison.Ordinal)+2);
			Console.WriteLine(suffix);
			string[] rounds = suffix.Split(";", StringSplitOptions.TrimEntries);
			foreach (var round in rounds) {
				string[] colors = round.Split(",", StringSplitOptions.TrimEntries);
				foreach (var color in colors) {
					string[] d = color.Split(" ");
					if (d[1].Equals("red")) redCount += int.Parse(d[0]);
					if (d[1].Equals("green")) greenCount += int.Parse(d[0]);
					if (d[1].Equals("blue")) blueCount += int.Parse(d[0]);
				}
			}
			Console.WriteLine($"Red: {redCount} Green: {greenCount} Blue: {blueCount}");
		}
	}
}