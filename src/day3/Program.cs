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

			int x = 0, y = 0;
			int treeCount = 0;
			while (y < input.Count - 1)
			{
				x += 3;
				y += 1;
				if (input[y][x % 31])
					treeCount++;
			}

			Console.WriteLine($"{treeCount} trees");
		}
	}
}
