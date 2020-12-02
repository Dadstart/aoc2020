using System;
using System.IO;
using System.Linq;

namespace day2
{
	class Program
	{
		static void Main(string[] args)
		{
			int valid = 0;
			int invalid = 0;

			// part 1
			using (var reader = new StreamReader(@"..\..\..\input.txt"))
			{
				while (!reader.EndOfStream)
				{
					// no input sanitization; but that's okay here
					var line = reader.ReadLine();

					int hyphen = line.IndexOf('-');
					var min = int.Parse(line.Substring(0, hyphen));

					int space = line.IndexOf(' ', hyphen + 1);
					var max = int.Parse(line.Substring(hyphen + 1, space - hyphen - 1));

					var letter = line[space + 1];

					var password = line.Substring(space + 3);

					var count = password.Where(c => c == letter).Count();
					if ((count >= min) && (count <= max))
						valid++;
					else
						invalid++;
				}
			}

			Console.WriteLine($"Valid: {valid}; Invalid: {invalid}");
		}
	}
}
