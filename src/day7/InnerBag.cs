using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace day7
{
	[DebuggerDisplay("{Name} ({Count})")]
	public class InnerBag
	{
		public string Name { get; }
		public int Count { get; }

		public InnerBag(string name, int count)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			if (count <= 0)
				throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive");
			Count = count;
		}
	}
}
