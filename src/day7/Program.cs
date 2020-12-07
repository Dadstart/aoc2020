using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day7
{
	class Program
	{
		static void Main(string[] args)
		{
			var bags = new Dictionary<string, Bag>();

			// day 1
			//const string inputFile = @"..\..\..\sample-input.txt";
			const string inputFile = @"..\..\..\input.txt";
			using (var reader = new StreamReader(inputFile))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length == 0)
						continue;

					// get name
					const string bagsContainStr = " bags contain ";
					var i = line.IndexOf(bagsContainStr);
					var bag = new Bag(line.Substring(0, i));
					bags.Add(bag.Name, bag);

					// skip " bags contain "
					i += bagsContainStr.Length;

					var innerBags = line.Substring(i);
					if (innerBags == "no other bags.")
						continue;

					var x = innerBags.Split(',');
					foreach (var innerBagStr in innerBags.Split(','))
					{
						int start = innerBagStr[0] == ' ' ? 1 : 0;
						var pos = innerBagStr.IndexOf(' ', start);
						var count = int.Parse(innerBagStr.Substring(start, pos));
						pos += 1;
						var end = innerBagStr.IndexOf(" bag");
						var name = innerBagStr.Substring(pos, end - pos);

						var innerBag = new InnerBag(name, count);
						bag.InnerBags.Add(innerBag);
					}
				}
			}

			var allGoldContainingBags = FindBagsContaining(bags.Values, bags["shiny gold"]);
			Console.WriteLine($"{allGoldContainingBags.Count} bags can eventually contain shiny gold");
		}

		static HashSet<Bag> FindBagsContaining(IEnumerable<Bag> allBags, Bag bag)
		{
			var bagsFound = new HashSet<Bag>();
			foreach (var bagFound in allBags.Where(b => b.HasInnerBag(bag.Name)))
			{
				bagsFound.Add(bagFound);
				var innerBags = FindBagsContaining(allBags, bagFound);
				foreach (var innerBag in innerBags)
				{
					if (!bagsFound.Contains(innerBag))
						bagsFound.Add(innerBag);
				}
			}

			return bagsFound;
		}
	}
}
