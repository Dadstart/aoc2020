using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace day7
{
	[DebuggerDisplay("{Name}; Inner Bags = {InnerBags.Count}")]
	public class Bag
	{
		public string Name { get; init; }
		public List<InnerBag> InnerBags { get; } = new List<InnerBag>();

		public Bag(string name)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public bool HasInnerBag(string name)
		{
			return InnerBags.FirstOrDefault(b => b.Name == name) != null;
		}
	}
}
