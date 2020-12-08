using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace day8
{
	[DebuggerDisplay("{Type} {Arg}")]
	public class Instruction
	{
		public InstructionType Type { get; }
		public int Arg { get; }
		public int ExecutionCount { get; set; }

		public Instruction(InstructionType type, int arg)
		{
			Type = type;
			Arg = arg;
		}
	}
}
