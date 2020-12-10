using System;
using System.Collections.Generic;
using System.IO;

namespace day9
{
	class Program
	{
		static void Main(string[] args)
		{
			// part 1
			var nums = new List<ulong>();
			//const string inputFile = @"..\..\..\sample-input.txt";
			const string inputFile = @"..\..\..\input.txt";
			using (var reader = new StreamReader(inputFile))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length == 0)
						continue;

					nums.Add(ulong.Parse(line));
				}
			}

			const int prevNumCount = 25;
			ulong invalidNum = 0;
			for (int pos = prevNumCount; pos < nums.Count; pos++)
			{
				bool found = false;
				for (int i = pos - prevNumCount; i < pos; i++)
				{
					for (int j = i + 1; j < pos; j++)
					{
						if (nums[i] + nums[j] == nums[pos])
						{
							found = true;
							break;
						}
					}

					if (found)
						break;
				}

				if (!found)
				{
					invalidNum = nums[pos];
					break;
				}
			}

			Console.WriteLine($"First invalid number is {invalidNum}");
		}
	}
}
