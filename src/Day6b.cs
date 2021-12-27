public partial class Day6 {
    public static long Day6b(string[] rawInput) {
			const int days = 256;
			var fishCount = new long[9];

			foreach (var ch in rawInput[0].Split(','))
				fishCount[int.Parse(ch)]++;

			for (var t = 0; t < days; t++)
				fishCount[(t + 7) % 9] += fishCount[t % 9];

			return fishCount.Sum();
		}
}