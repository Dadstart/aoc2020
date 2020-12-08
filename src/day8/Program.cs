using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day8
{
	class Program
	{
		static void Main(string[] args)
		{
			var instructions = new List<Instruction>();
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

					var match = Regex.Matches(line, @"\b(?<op>\w\w\w)\s(?<argSign>[+-])(?<argNum>\d+)").First();

					InstructionType type;
					switch (match.Groups["op"].Value)
					{
						case "nop":
							type = InstructionType.Nop;
							break;
						case "jmp":
							type = InstructionType.Jmp;
							break;
						case "acc":
							type = InstructionType.Acc;
							break;
						default:
							throw new InvalidOperationException($"Unknown instruction type {match.Groups["op"].Value}");
					}

					var arg = int.Parse(match.Groups["argNum"].Value);
					if (match.Groups["argSign"].Value == "-")
						arg *= -1;

					instructions.Add(new Instruction(type, arg));
				}
			}

			int i = 0;
			int acc = 0;
			while (i < instructions.Count)
			{
				var instr = instructions[i];
				if (instr.ExecutionCount > 0)
					break;

				switch (instr.Type)
				{
					case InstructionType.Acc:
						acc += instr.Arg;
						i++;
						break;
					case InstructionType.Jmp:
						i += instr.Arg;
						break;
					case InstructionType.Nop:
						i++;
						break;
				}

				instr.ExecutionCount++;
			}

			Console.WriteLine($"Halted at instruction {i}. Accumulator value {acc}");
		}
	}
}
