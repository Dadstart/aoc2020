using System;
using System.Collections.Generic;
using System.IO;

namespace day10
{
	class Program
	{
		static void Main(string[] args)
		{
			// part 1
			var adapters = new List<int>();
			//const string inputFile = @"..\..\..\sample-input2.txt";
			const string inputFile = @"..\..\..\input.txt";
			using (var reader = new StreamReader(inputFile))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length == 0)
						continue;

					adapters.Add(int.Parse(line));
				}
			}

			var voltDiffs = new int[] { 0, 0, 0, 0};
			adapters.Sort();

			// add outlet of 0 jolts
			adapters.Insert(0, 0);

			// add built-in adapter of +3 jolts
			adapters.Add(adapters[adapters.Count - 1] + 3);

			for (int i = 1; i < adapters.Count; i++)
			{
				var diff = adapters[i] - adapters[i - 1];
				voltDiffs[diff]++;
			}

			Console.WriteLine($"1-volt diffs: {voltDiffs[1]}; 3-volt diffs: {voltDiffs[3]}");
			Console.WriteLine($"Product is {voltDiffs[1] * voltDiffs[3]}");
		}
	}
}
