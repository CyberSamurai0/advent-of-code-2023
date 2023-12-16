namespace advent_of_code.three; 

public class GearRatios {
	private static readonly FileInput F = new ("./inputs/three.txt");

	public static void Run() {
		Console.WriteLine("Advent of Code 2023 Day 3: Gear Ratios");
		Console.WriteLine($"{F.Lines.Length} loaded");

		var sum = 0;
		for (var row = 0; row < F.Lines.Length; row++) {
			var line = F.Lines[row];

			for (var col = 0; col < line.Length; col++) {
				var c = line[col];

				if (char.IsDigit(c)) {
					// Check if we've already processed this number sequence
					if (col >= 1 && char.IsDigit(line[col-1])) continue;
					// Assume we have not, check the subsequent characters until we determine the sequence length
					int end = line.Length;
					for (var x = col + 1; x < line.Length; x++) {
						if (char.IsDigit(line[x])) continue;
						end = x;
						break;
					}
					var seq = line.Substring(col, end-col);
					Console.WriteLine(seq);
					
					// Analyze the surrounding characters for symbols
					int surroundStartCol = col > 0 ? col - 1 : col;
					int surroundEndCol = end < line.Length - 1 ? end + 1 : end; // Exclude!

					string surround = "";
					// Determine if we should check the previous line
					if (row > 0) surround += F.Lines[row - 1]
							.Substring(surroundStartCol, surroundEndCol - surroundStartCol);

					// Determine if we should check either side of the sequence
					if (surroundStartCol != col) surround += line[surroundStartCol];
					if (surroundEndCol != end) surround += line[surroundEndCol-1];
					
					// Determine if we should check the next line
					if (row < F.Lines.Length - 1) surround += F.Lines[row + 1]
						.Substring(surroundStartCol, surroundEndCol - surroundStartCol);
					
					Console.WriteLine(line.Substring(surroundStartCol, line.Length-surroundStartCol));
					Console.WriteLine($"Surrounding ({surround.Length}) {surround}");
					
					// Iterate over each character and check that it is neither "." nor digit
					foreach (var sc in surround) {
						if (sc.Equals('.') || char.IsDigit(sc)) continue;
						// Symbol found
						sum += int.Parse(seq);
						Console.WriteLine($"{seq} is a part number");
						Console.WriteLine($"{row}: {seq}");
						break;
					}
					
				}
			}
		}
		Console.WriteLine($"Sum (pt. 1): {sum}");
	}
}