using System;
using System.Collections.Generic;
using System.IO;

namespace day3
{
	class Program
	{
		static void Main(string[] args)
		{
			// part 1
			var input = new List<bool[]>();
			using (var reader = new StreamReader(@"..\..\..\input.txt"))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length < 31)
						return;

					var mapRow = new bool[31];
					for (int i = 0; i < 31; i++)
					{
						mapRow[i] = line[i] == '#';
					}

					input.Add(mapRow);
				}
			}
			
			var treeCount = CountTrees(input, 3, 1);
			Console.WriteLine($"{treeCount} trees");

			// part 2
			var counts = new List<ulong>();

			counts.Add(CountTrees(input, 1, 1));
			counts.Add(CountTrees(input, 3, 1));
			counts.Add(CountTrees(input, 5, 1));
			counts.Add(CountTrees(input, 7, 1));
			counts.Add(CountTrees(input, 1, 2));

			ulong mult = 1;
			foreach (var count in counts)
			{
				mult *= count;
			}

			Console.WriteLine($"Big Tree Number: {mult}");
		}

		private static ulong CountTrees(List<bool[]> input, int dx, int dy)
		{
			int x = 0, y = 0;
			ulong treeCount = 0;
			while (y < input.Count - dy)
			{
				x += dx;
				y += dy;
				if (input[y][x % 31])
					treeCount++;
			}

			return treeCount;
		}
	}
}
