// See https://aka.ms/new-console-template for more information

using advent_of_code.one;
using advent_of_code.two;

string day = args.Length >= 1 ? args[0] : "1";

if (day.Equals("1")) Trebuchet.Run();
else if (day.Equals("2")) CubeConundrum.Run();