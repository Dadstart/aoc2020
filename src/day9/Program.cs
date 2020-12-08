using System;
using System.IO;

namespace day9
{
	class Program
	{
		static void Main(string[] args)
		{
			// part 1
			const string inputFile = @"..\..\..\sample-input.txt";
			//const string inputFile = @"..\..\..\input.txt";
			using (var reader = new StreamReader(inputFile))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length == 0)
						continue;

				}
			}
		}
	}
}
