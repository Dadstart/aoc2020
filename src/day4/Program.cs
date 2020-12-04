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
			foreach (var passport in passports)
			{
				if (!ValidateFieldsDay1(passport, "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"))
					continue;

				validPassports++;
			}

			Console.WriteLine($"Total valid passports: {validPassports}");

			// day 2
			validPassports = 0;
			foreach (var passport in passports)
			{
				if (!ValidateFieldsDay2(passport))
					continue;

				validPassports++;
			}

			Console.WriteLine($"Total valid passports: {validPassports}");
		}

		static bool ValidateFieldsDay1(Dictionary<string, string> passport, params string[] fields)
		{
			foreach (var field in fields)
			{
				if (!passport.ContainsKey(field))
					return false;
			}

			return true;
		}

		static bool ValidateFieldsDay2(Dictionary<string, string> passport)
		{
			return ValidateYearField(passport, "byr", 1920, 2002)
				&& ValidateYearField(passport, "iyr", 2010, 2020)
				&& ValidateYearField(passport, "eyr", 2020, 2030)
				&& ValidateHeight(passport)
				&& ValidateHairColor(passport)
				&& ValidateEyeColor(passport)
				&& ValidatePassportId(passport);

		}

		private static bool ValidatePassportId(Dictionary<string, string> passport)
		{
			if (!passport.TryGetValue("pid", out string strVal))
				return false;

			if (strVal.Length != 9)
				return false;

			foreach (var ch in strVal)
			{
				if ((ch < '0') || (ch > '9'))
					return false;
			}

			return true;
		}

		private static bool ValidateEyeColor(Dictionary<string, string> passport)
		{
			if (!passport.TryGetValue("ecl", out string strVal))
				return false;

			switch (strVal)
			{
				case "amb":
				case "blu":
				case "brn":
				case "gry":
				case "grn":
				case "hzl":
				case "oth":
					return true;
				default:
					return false;
			}
		}

		private static bool ValidateHairColor(Dictionary<string, string> passport)
		{
			if (!passport.TryGetValue("hcl", out string strVal))
				return false;

			if (strVal.Length != 7)
				return false;

			if (!strVal.StartsWith('#'))
				return false;

			for (int i = 1; i < strVal.Length; i++)
			{
				var ch = strVal[i];
				if (!((ch >= '0') && (ch <= '9'))
					&& !((ch >= 'a') && (ch <= 'f')))
				{
					return false;
				}
			}

			return true;
		}

		static bool ValidateHeight(Dictionary<string, string> passport)
		{
			if (!passport.TryGetValue("hgt", out string strVal))
				return false;
			if (strVal.EndsWith("cm"))
			{
				var height = int.Parse(strVal.Substring(0, strVal.Length - 2));
				return (height >= 150) && (height <= 193);
			}
			else if (strVal.EndsWith("in"))
			{
				var height = int.Parse(strVal.Substring(0, strVal.Length - 2));
				return (height >= 59) && (height <= 76);
			}
			else
			{
				return false;
			}
		}

		static bool ValidateYearField(Dictionary<string, string> passport, string key, int min, int max)
		{
			if (!passport.TryGetValue(key, out string val))
				return false;

			var year = int.Parse(val);
			return (year >= min) && (year <= max);
		}
	}
}
