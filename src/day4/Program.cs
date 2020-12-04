using System;
using System.Collections.Generic;
using System.IO;

namespace day4
{
	class Program
	{
		static void Main(string[] args)
		{
			// day 1
			const string inputFile = @"..\..\..\input.txt";
			var passports = new List<Dictionary<string, string>>();
			using (var reader = new StreamReader(inputFile))
			{
				Dictionary<string, string> values = null;
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length == 0)
					{
						if (values != null)
						{
							passports.Add(values);
							values = null;
						}
					}
					else
					{
						if (values == null)
							values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

						var fields = line.Split(' ');
						foreach (var field in fields)
						{
							var fieldSplit = field.Split(':');
							values[fieldSplit[0]] = fieldSplit[1];
						}
					}

				}

				if (values != null)
					passports.Add(values);
			}

			var validPassports = 0;
			var validNorthPolePassports = 0;
			foreach (var passport in passports)
			{
				if (!ValidateFields(passport, "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"))
					continue;

				if (passport.ContainsKey("cid"))
					validPassports++;
				else
					validNorthPolePassports++;
			}

			Console.WriteLine($"Total valid passports: {validPassports + validNorthPolePassports}");
		}

		static bool ValidateFields(Dictionary<string, string> passport, params string[] fields)
		{
			foreach (var field in fields)
			{
				if (!passport.ContainsKey(field))
					return false;
			}

			return true;
		}
	}
}
