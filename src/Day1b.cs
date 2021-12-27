public partial class Day1 {
    public static int Day1b(string[] rawInput) {
        int[] input = rawInput.Select(int.Parse).ToArray();

        var measurements = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
            if (input.Length >= i+3)
                measurements[i] = input[i] + input[i+1] + input[i+2];
        
        int lastN = 0, c = 0;
        foreach (var n in measurements) {
            if (lastN != 0 && n > lastN)
                c++;
            lastN = n;
        }
        return c;
    }
}