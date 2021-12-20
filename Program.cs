using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
    public class Program {
        public static void Main() => Console.WriteLine(Day3(File.ReadAllLines("input/day3.txt")));

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
					// Part 2:
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
    }
}