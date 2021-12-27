using System.Reflection;

namespace AdventOfCode {
    public class Program {
        public static void Main() {
			string? @class;
			while ((@class = Console.ReadLine()) != null) {
				@class = @class.Trim().Replace(" ", "");
				var t = Type.GetType(@class.Remove(@class.Length-1));
				if (t != null)
					Console.WriteLine("Result: " + t.GetMethod(@class, BindingFlags.Public | BindingFlags.Static).Invoke(null, new [] { File.ReadAllLines($"input/{t.Name.ToLower()}.txt") }));
				else Console.WriteLine($"'{@class}' doesn't exist!");
			}
		}
	}
}