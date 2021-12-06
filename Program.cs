using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode {
    public class Program {
        public static void Main() => Console.WriteLine(Day2(File.ReadAllLines("input/day2.txt")));

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
    }
}