public partial class Day4 {
    public static int Day4b(string[] rawInput) {
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
                            winningBoards.Add(y, n * Enumerable.Range(y, 5).Select(yy => Enumerable.Range(0, 5).Select(x => !mat[yy,x] ? int.Parse(rawInput[yy].Split(' ', StringSplitOptions.RemoveEmptyEntries)[x]) : 0).Sum()).Sum());
                    }
        }
        return winningBoards.Last().Value;
    }
}