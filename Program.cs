using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
    public class Program {
        public static void Main() => Console.WriteLine(Day4(File.ReadAllLines("input/day4.txt")));

        public static int Day1(string[] rawInput) {
			int[] input = rawInput.Select(int.Parse).ToArray();

			// Part 2: 1575
			var measurements = new int[input.Length];
			for (int i = 0; i < input.Length; i++)
				if (input.Length >= i+3)
                	measurements[i] = input[i] + input[i+1] + input[i+2];
			
			// Part 1: 1527
            int lastN = 0, c = 0;
            foreach (var n in measurements) {
                if (lastN != 0 && n > lastN)
                    c++;
                lastN = n;
            }
			return c;
        }

		public static int Day2(string[] rawInput) {
			int h = 0, d = 0, a = 0;

			// Part 1: 1727835
			/* foreach (var line in rawInput) {
				var cmd = line.Split(' ');
				h += cmd[0] == "forward" ? int.Parse(cmd[1]) : 0;
				d += cmd[0] == "up" ? int.Parse(cmd[1])*-1 : cmd[0] == "down" ? int.Parse(cmd[1]) : 0;
			}*/

			// Part 2: 1544000595
			foreach (var line in rawInput) {
				var cmd = line.Split(' ');
				int f = cmd[0] == "forward" ? int.Parse(cmd[1]) : 0;
				h += f;
				d += f*a;
				a += cmd[0] == "up" ? int.Parse(cmd[1])*-1 : cmd[0] == "down" ? int.Parse(cmd[1]) : 0;
			}
			return h*d;
		}

		public static int Day3(string[] rawInput) {
			//var bits = new BitArray(12);
			int[] result = new int[2];

			for (int r = 0; r < 2; r++) {
				string[] input = rawInput;
				for (int i = 0; i < 12; i++) {
					// Part 1: 1540244
					// if current bit row has more 1s, set current bit
					// bits[11-i] = rawInput.Where(binary => binary[i] == '1').Count() > rawInput.Where(binary => binary[i] == '0').Count() ? true : false;
					// Part 2: 4203981
					int o = input.Where(binary => binary[i] == '1').Count(), z = input.Where(binary => binary[i] == '0').Count();
					if ((input = input.Where(binary => binary[i] == (o > z || o == z ? r == 0 ? '0':'1' : r == 0 ? '1':'0')).ToArray()).Count() == 1) {
						result[r] = Convert.ToInt32(input.First(), 2);
						break;
					}
				}
			}
			
			// (Part 1) convert bits to int and invert
			/*bits.CopyTo(result, 0); // gamma
			bits.Not();
			bits.CopyTo(result, 1);*/ // epsilon
			return result[0] * result[1];
		}

		public static int Day4(string[] rawInput) {
			bool[,] mat = new bool[rawInput.Length, 5];
			int[] numbers = rawInput[0].Split(',').Select(int.Parse).ToArray();
			var winningBoards = new Dictionary<int, int>(); // yPos + score

			for (int i = 0; i < numbers.Length; i++) {
				int n = numbers[i];
				for (int y = 2; y < rawInput.Length; y++) // go through boards and mark current number
					if (!string.IsNullOrWhiteSpace(rawInput[y])) {
						string[] line = rawInput[y].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
						for (int x = 0; x < 5; x++)
							if (line[x] == n.ToString())
								mat[y,x] = true;
					}

				if (i >= 5) // after marking atleast 5 numbers, check if a row or column is finished
					for (int d = 0; d < 2; d++) // dir 0 = columns, dir 1 = rows
						for (int y = 2; y < rawInput.Length; y += 6) {
							if (string.IsNullOrWhiteSpace(rawInput[y]) // skip empty line
								|| winningBoards.ContainsKey(y)) // skip finished board
								continue;
							// check for finished row horizontally and vertically
							if (Enumerable.Range(d==0 ? 0:y, 5).Where(a => Enumerable.Range(d == 0 ? y:0, 5).Where(b => mat[d==0 ? b:a, d==0 ? a:b]).Count() == 5).Count() >= 1)
								// calculate score from unmarked numbers
								// Part 1: 74320
								winningBoards.Add(y, n * Enumerable.Range(y, 5).Select(yy => Enumerable.Range(0, 5).Select(x => !mat[yy,x] ? int.Parse(rawInput[yy].Split(' ', StringSplitOptions.RemoveEmptyEntries)[x]) : 0).Sum()).Sum());
						}
			}
			// Part 2: 17884
			return winningBoards.Last().Value;
		}
    }
}