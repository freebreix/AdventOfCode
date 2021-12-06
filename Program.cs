using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode {
    public class Program {
        public static void Main() => Console.WriteLine(Day1(File.ReadAllLines("input/day1.txt")));

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
    }
}