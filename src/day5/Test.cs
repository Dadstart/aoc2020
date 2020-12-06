using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace day5
{
	public static class Test
	{
		public static void AssertEqual(int val, int expected)
		{
			if (val != expected)
				throw new Exception($"Expected {expected}; Actual {val}");
		}
	}
}
