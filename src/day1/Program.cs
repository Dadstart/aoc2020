using System;
using System.Collections.Generic;
using System.IO;

namespace day1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			--- Day 1: Report Repair ---

			Before you leave, the Elves in accounting just need you to fix your expense report
			(your puzzle input); apparently, something isn't quite adding up.

			Specifically, they need you to find the two entries that sum to 2020 and then multiply
			those two numbers together.

			For example, suppose your expense report contained the following:

			1721
			979
			366
			299
			675
			1456
			In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them
			together produces 1721 * 299 = 514579, so the correct answer is 514579.

			Of course, your expense report is much larger. Find the two entries that sum to 2020;
			what do you get if you multiply them together?
			*/

			List<int> inputList = new List<int>();
			using (var reader = new StreamReader(@"..\..\..\input.txt"))
			{
				while (!reader.EndOfStream)
				{
					var str = reader.ReadLine();
					inputList.Add(int.Parse(str));
				}
			}

			int entry1 = 0;
			int entry2 = 0;
			bool found = false;

			for (int i = 0; i < inputList.Count; i++)
			{
				for (int j = i + 1; j < inputList.Count; j++)
				{
					if (inputList[i] + inputList[j] == 2020)
					{
						entry1 = inputList[i];
						entry2 = inputList[j];
						found = true;
						break;
					}

					if (found)
						break;
				}
			}

			Console.WriteLine($"{entry1} x {entry2} = {entry1 * entry2}");
		}
	}
}
