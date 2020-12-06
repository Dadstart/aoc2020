using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day6
{
	class Program
	{
		static void Main(string[] args)
		{
			// day 1
			var groups = new List<List<string>>();

			//const string inputFile = @"..\..\..\sample-input.txt";
			const string inputFile = @"..\..\..\input.txt";
			using (var reader = new StreamReader(inputFile))
			{
				var group = new List<string>();
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length == 0)
					{
						groups.Add(group);
						group = new List<string>();
					}
					else
					{
						group.Add(line);
					}
				}

				if (group.Count != 0)
					groups.Add(group);
			}

			// get sum
			var sum = 0;
			foreach (var group in groups)
			{
				var groupConcat = string.Empty;
				foreach (var entry in group)
					groupConcat += entry;

				var groupSum = groupConcat.Distinct().Count();
				sum += groupSum;
			}

			Console.WriteLine($"Sum {sum}");

			// part 2
			sum = 0;
			foreach (var group in groups)
			{
				IEnumerable<char> groupAnswers = null;
				foreach (var entry in group)
				{
					if (groupAnswers == null)
					{
						groupAnswers = entry;
					}
					else
					{
						groupAnswers = groupAnswers.Intersect(entry);
					}
				}

				sum += groupAnswers.Count();
			}
			Console.WriteLine($"Sum {sum}");
		}
	}
}
