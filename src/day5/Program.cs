using System;
using System.Collections.Generic;
using System.IO;

namespace day5
{
	class Program
	{
		static void Main(string[] args)
		{
			// day 1
			TestGetSeat("FBFBBFFRLR",  44, 5, 357);
			TestGetSeat("BFFFBBFRRR",  70, 7, 567);
			TestGetSeat("FFFBBBFRRR",  14, 7, 119);
			TestGetSeat("BBFFBBFRLL", 102, 4, 820);

			var highestSeat = 0;
			var seats = new List<int>();
			using (var reader = new StreamReader(@"..\..\..\input.txt"))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (line.Length == 0)
						continue;

					var seat = GetSeat(line);
					if (seat.id > highestSeat)
						highestSeat = seat.id;

					seats.Add(seat.id);
				}
			}

			Console.WriteLine($"Highest seat id: {highestSeat}");

			// day 2
			seats.Sort();
			int missingSeat = -1;
			for (int i = 1; i < seats.Count - 1; i++)
			{
				if (seats[i - 1] != seats[i] - 1)
					missingSeat = seats[i] - 1;
			}
			Console.WriteLine($"Assigned seat id: {missingSeat}");
		}

		static void TestGetSeat(string input, int row, int col, int id)
		{
			// I should really start using xUnit
			var seat = GetSeat(input);
			Test.AssertEqual(seat.row, row);
			Test.AssertEqual(seat.col, col);
			Test.AssertEqual(seat.id, id);
		}

		static (int row, int col, int id) GetSeat(string input)
		{
			int row = -1;
			int col = -1;
			int id = -1;

			row = GetLocation(input.Substring(0, 7), 'F', 'B', 0, 127);
			col = GetLocation(input.Substring(7, 3), 'L', 'R', 0, 7);
			id = row * 8 + col;

			return (row, col, id);
		}

		static int GetLocation(string input, char lower, char higher, int min, int max)
		{
			foreach (char ch in input)
			{
				if (ch == lower)
				{
					max = ((max - min) / 2) + min;
				}
				else if (ch == higher)
				{
					min = (max - min) / 2 + min + 1;
				}
				else
				{
					throw new InvalidOperationException($"Invalid char '{ch}'");
				}
			}

			if (min != max)
				throw new InvalidOperationException($"Did not find value");

			return min;
		}
	}
}
