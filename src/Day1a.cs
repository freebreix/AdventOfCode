public partial class Day1 {
    public static int Day1a(string[] rawInput) {
        int lastN = 0, c = 0;
        foreach (var n in rawInput.Select(int.Parse).ToArray()) {
            if (lastN != 0 && n > lastN)
                c++;
            lastN = n;
        }
        return c;
    }
}